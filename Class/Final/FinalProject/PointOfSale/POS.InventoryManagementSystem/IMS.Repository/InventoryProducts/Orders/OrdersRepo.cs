using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    public class OrdersRepo
    {
        private InventoryDBDataAccess iDB      { get; set; }
        
        public OrdersRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }


        public string GetTodaySell()
        {
            return iDB.GetSingleData("select count(orderid) as totalsell from orders where date=format(getdate(),'yyyy-MM-dd')", "totalsell");
        }
        public string GetTotalOrders()
        {
            return iDB.GetSingleData("select count(orderid) as totalsell from orders", "totalsell");
        }
        public string GetLastWeekSell()
        {
            return iDB.GetSingleData("select sum(TotalAmount) as sum from orders where date<GETDATE() and date>DATEADD(day,-8, GETDATE())", "sum");
        }
        public string GetLastMonthSell()
        {
            return iDB.GetSingleData("select sum(TotalAmount) as sum from orders where date<GETDATE() and date>DATEADD(day,-31, GETDATE())", "sum");
        }


        //view & search & filter 
        public DataTable GetAll(string key)
        {
           // List<Orders> ordersList = new List<Orders>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"select
                                    p.ProductId as 'ProductId', p.ProductIdTag as 'ProductIdTag', p.ProductName as 'ProductName',
                                    p.ProductStatus AS ProductStatus,
		                            p.ProductPerUnitPrice AS ProductPerUnitPrice, p.ProductUnitStock AS ProductUnitStock,
		                            p.ProductMSRP AS ProductMSRP, p.ProductDiscountRate AS ProductDiscountRate,
                                    b.BrandName AS BrandName, v.VendorName VendorName,
		                            tc.ThirdCategoryName AS ThirdCategoryName,
		                            sc.SecondCategoryName AS SecondCategoryName
                                    from Products as p
                                    left join brands as b on b.BrandId = p.BrandId
                                    left join vendors as v on v.VendorId=b.VendorId
                                    left join ThirdCategories as tc on v.ThirdCategoryId=tc.ThirdCategoryId
                                    left join SecondCategories as sc on tc.SecondCategoryId=sc.SecondCategoryId
                                    
                                    where p.ProductStatus like 'Yes';";
                else
                    sql = @"select  
                                    p.ProductId as ProductId, p.ProductIdTag as ProductIdTag, p.ProductName as ProductName,
                                    p.ProductStatus AS ProductStatus,
		                            p.ProductPerUnitPrice AS ProductPerUnitPrice, p.ProductUnitStock AS ProductUnitStock,
		                            p.ProductMSRP AS ProductMSRP, p.ProductDiscountRate AS ProductDiscountRate,
                                    b.BrandName AS BrandName, v.VendorName VendorName,
		                            tc.ThirdCategoryName AS ThirdCategoryName,
		                            sc.SecondCategoryName AS SecondCategoryName
                                    from Products as p
                                    left join brands as b on b.BrandId = p.BrandId
                                    left join vendors as v on v.VendorId=b.VendorId
                                    left join ThirdCategories as tc on v.ThirdCategoryId=tc.ThirdCategoryId
                                    left join SecondCategories as sc on tc.SecondCategoryId=sc.SecondCategoryId 
                                
                                    where sc.SecondCategoryName like '%" + key + "%' ";

                return this.iDB.ExecuteQueryTable(sql);
                
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        //Order History
        public DataTable GetAllOrderHistory(string key)
        {
            List<Orders> ordersHistoryList = new List<Orders>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"select
                                  Orders.OrderId AS OrderId, Orders.OrderTag AS OrderTag, Users.UserId AS UserId,
			                      Orders.Date AS Date, Orders.ProductId AS ProductId, Orders.ProductName AS ProductName,
			                      Orders.ProductPerUnitPrice AS ProductPerUnitPrice,
			                      Orders.OrderQuantity AS OrderQuantity, Orders.TotalAmount AS TotalAmount,
			                      Orders.PaymentMethod AS PaymentMethod,

			                      Users.FirstName AS FirstName, Users.LastName AS LastName,
			                      
			                      Orders.CustomerFullName AS CustomerFullName, Orders.CustomerPhone AS CustomerPhone,
			                      Orders.CustomerEmail AS CustomerEmail, Orders.CustomerAddress AS CustomerAddress,
			                      
			                      Orders.BarCodeId AS BarCodeId

                                  FROM Orders INNER JOIN
                                  Users ON Orders.Id = Users.Id ;";
                else
                    sql = @"select
                                  Orders.OrderId AS OrderId, Orders.OrderTag AS OrderTag, Users.UserId AS UserId,
			                      Orders.Date AS Date, Orders.ProductId AS ProductId, Orders.ProductName AS ProductName,
			                      Orders.ProductPerUnitPrice AS ProductPerUnitPrice,
			                      Orders.OrderQuantity AS OrderQuantity, Orders.TotalAmount AS TotalAmount,
			                      Orders.PaymentMethod AS PaymentMethod,

			                      Users.FirstName AS FirstName, Users.LastName AS LastName,
			                      
			                      Orders.CustomerFullName AS CustomerFullName, Orders.CustomerPhone AS CustomerPhone,
			                      Orders.CustomerEmail AS CustomerEmail, Orders.CustomerAddress AS CustomerAddress,
			                      
			                      Orders.BarCodeId AS BarCodeId

                                  FROM Orders INNER JOIN
                                  Users ON Orders.Id = Users.Id 
                                
                                  where Orders.OrderId like '%" + key + "%' or Orders.OrderTag like '%" + key + "%' or " +
                                  " Users.UserId like '%" + key + "%' or Orders.Date like '%" + key + "%' or " +
                                  " Orders.ProductId like '%" + key + "%' or Orders.ProductName like '%" + key + "%' or " +
                                  " Orders.ProductPerUnitPrice like '%" + key + "%' or Orders.OrderQuantity like '%" + key + "%' or " +
                                  " Orders.TotalAmount like '%" + key + "%' or Orders.PaymentMethod like '%" + key + "%' or " +
                                  " Users.FirstName like '%" + key + "%' or Users.LastName like '%" + key + "%' or " +
                                  " Orders.CustomerFullName like '%" + key + "%' or  Orders.CustomerPhone like '%" + key + "%' or " +
                                  " Orders.CustomerEmail like '%" + key + "%' or Orders.CustomerAddress like '%" + key + "%' or " +
                                  " Orders.BarCodeId like '%" + key + "%' ";

                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        //view & search & filter 
        public List<Orders> GetAll2(string key)
        {
            List<Orders> ordersList = new List<Orders>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"select
                                    p.ProductId as 'ProductId', p.ProductIdTag as 'ProductIdTag', p.ProductName as 'ProductName',
                                    p.ProductStatus AS ProductStatus,
		                            p.ProductPerUnitPrice AS ProductPerUnitPrice, p.ProductUnitStock AS ProductUnitStock,
		                            p.ProductMSRP AS ProductMSRP, p.ProductDiscountRate AS ProductDiscountRate,
                                    b.BrandName AS BrandName, v.VendorName VendorName,
		                            tc.ThirdCategoryName AS ThirdCategoryName,
		                            sc.SecondCategoryName AS SecondCategoryName
                                    from Products as p
                                    left join brands as b on b.BrandId = p.BrandId
                                    left join vendors as v on v.VendorId=b.VendorId
                                    left join ThirdCategories as tc on v.ThirdCategoryId=tc.ThirdCategoryId
                                    left join SecondCategories as sc on tc.SecondCategoryId=sc.SecondCategoryId
                                    
                                    where p.ProductStatus like 'Yes';";
                else
                    sql = @"select  
                                    p.ProductId as ProductId, p.ProductIdTag as ProductIdTag, p.ProductName as ProductName,
                                    p.ProductStatus AS ProductStatus,
		                            p.ProductPerUnitPrice AS ProductPerUnitPrice, p.ProductUnitStock AS ProductUnitStock,
		                            p.ProductMSRP AS ProductMSRP, p.ProductDiscountRate AS ProductDiscountRate,
                                    b.BrandName AS BrandName, v.VendorName VendorName,
		                            tc.ThirdCategoryName AS ThirdCategoryName,
		                            sc.SecondCategoryName AS SecondCategoryName
                                    from Products as p
                                    left join brands as b on b.BrandId = p.BrandId
                                    left join vendors as v on v.VendorId=b.VendorId
                                    left join ThirdCategories as tc on v.ThirdCategoryId=tc.ThirdCategoryId
                                    left join SecondCategories as sc on tc.SecondCategoryId=sc.SecondCategoryId 
                                
                                    where sc.SecondCategoryName like '%" + key + "%' ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Orders o = this.ConvertToEntity(dt.Rows[x]);
                    ordersList.Add(o);
                    x++;
                }
                return ordersList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Orders ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var orders = new Orders();
            orders.ProductName = row["ProductName"].ToString(); 
            orders.ProductId = Convert.ToInt32(row["ProductId"].ToString());
            orders.ProductIdTag = row["ProductIdTag"].ToString();
            orders.ProductUnitStock = Convert.ToInt32(row["ProductUnitStock"].ToString());
            orders.ProductPerUnitPrice = Convert.ToDouble(row["ProductPerUnitPrice"].ToString());
            orders.ProductDiscountRate = Convert.ToDouble(row["ProductDiscountRate"].ToString());
            orders.ProductMSRP = Convert.ToDouble(row["ProductMSRP"].ToString());
            orders.ProductStatus = row["ProductStatus"].ToString();
            orders.BrandName = row["BrandName"].ToString();
            orders.VendorName = row["VendorName"].ToString();
            orders.ThirdCategoryName = row["ThirdCategoryName"].ToString();
            orders.SecondCategoryName = row["SecondCategoryName"].ToString();
            return orders;
        }

        //for - Orders
        public List<Orders> GetAllForOrders()
        {
            List<Orders> ordersList = new List<Orders>();
            string sql;

            try
            {
                sql = @"SELECT      
		                      Orders.OrderId AS OrderId,
		                      Orders.OrderTag AS OrderTag,

		                      Users.Id AS Id,
		                      
		                      BarCodes.BarCodeId AS BarCodeId,
		                      Orders.Date AS Date,
		                      Products.ProductId AS ProductId,
                              Products.ProductName AS ProductName,
                              Products.ProductPerUnitPrice AS ProductPerUnitPrice,
		                      Orders.OrderQuantity AS OrderQuantity,
		                      Orders.OrderStatus AS OrderStatus,
		                      Orders.PaymentMethod AS PaymentMethod,
		                      Orders.TotalAmount AS TotalAmount,
		                      Orders.CustomerFullName AS CustomerFullName,
		                      Orders.CustomerPhone AS CustomerPhone,
		                      Orders.CustomerEmail AS CustomerEmail,
		                      Orders.CustomerAddress AS CustomerAddress
		                      From
                              Orders INNER JOIN
		                      Products ON Orders.ProductId = Products.ProductId INNER JOIN
                              
						      BarCodes ON Orders.BarCodeId = BarCodes.BarCodeId INNER JOIN
                              Users ON Orders.Id = Users.Id";
                
            var dt = this.iDB.ExecuteQueryTable(sql);

            int x = 0;
                while (x < dt.Rows.Count)
                {
                    Orders o = this.ConvertToEntityForOrders(dt.Rows[x]);
                    ordersList.Add(o);
                    x++;
                }
                return ordersList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Orders ConvertToEntityForOrders(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var orders = new Orders();
            orders.CustomerEmail = row["CustomerEmail"].ToString();
            orders.CustomerAddress = row["CustomerAddress"].ToString(); 
            orders.CustomerPhone = row["CustomerPhone"].ToString();
            orders.CustomerFullName = row["CustomerFullName"].ToString();
            //
            orders.Id = Convert.ToInt32(row["Id"].ToString());
            //
            orders.ProductId = Convert.ToInt32(row["ProductId"].ToString());
            orders.ProductName = row["ProductName"].ToString();
            orders.ProductPerUnitPrice = Convert.ToDouble(row["ProductPerUnitPrice"].ToString());
            //orders.ProductDiscountRate = Convert.ToDouble(row["ProductDiscountRate"].ToString());
            //orders.ProductMSRP = Convert.ToDouble(row["ProductMSRP"].ToString());
            //
            orders.OrderId = Convert.ToInt32(row["Orderid"].ToString());
            orders.OrderQuantity = Convert.ToInt32(row["OrderQuantity"].ToString());
            orders.Date = Convert.ToDateTime(row["Date"].ToString()); 
            orders.TotalAmount = Convert.ToDouble(row["TotalAmount"].ToString()); 
            orders.OrderStatus = row["OrderStatus"].ToString();
            orders.PaymentMethod = row["PaymentMethod"].ToString();
            //
            orders.BarCodeId = Convert.ToInt32(row["BarCodeId"].ToString());
            return orders;
        }

        //SaveData - Orders 
        public bool SaveOrders(List<Orders> orders)
        {
            bool saveSuccesful = false;
            //List<Orders> orders = GetAllForOrders();

            foreach (Orders or in orders)
            {
                string sql = "insert into Orders (Id, BarCodeId, Date, ProductId, ProductName, ProductPerUnitPrice, OrderQuantity," +
                             "OrderStatus, PaymentMethod, " +
                             "TotalAmount, CustomerFullName, CustomerPhone, CustomerEmail, CustomerAddress) " +
                             " values ('" + or.Id + "', " +
                             " '" + or.BarCodeId + "' , '" + or.Date + "' , '" + or.ProductId + "' ," +
                             " '" + or.ProductName + "' ,  '" + or.ProductPerUnitPrice + "' , " +
                             " '" + or.OrderQuantity + "' , '" + or.OrderStatus + "' , '" + or.PaymentMethod + "' ," +
                             " '" + or.TotalAmount + "' ," +
                             " '" + or.CustomerFullName + "' , '" + or.CustomerPhone + "' , '" + or.CustomerEmail + "' ," +
                             " '" + or.CustomerAddress + "') ";
                try
                {
                    this.iDB.ExecuteDMLQuery(sql);
                    saveSuccesful = true;
                }
                catch (Exception e)
                {
                    saveSuccesful = false;
                    Debug.WriteLine(e.ToString());
                    break;
                }
            }
            return saveSuccesful;
        }
    }
}
