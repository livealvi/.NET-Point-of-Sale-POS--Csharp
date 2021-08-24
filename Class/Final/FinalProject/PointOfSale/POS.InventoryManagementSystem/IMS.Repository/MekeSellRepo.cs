using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity;

namespace IMS.Repository
{
    public class MekeSellRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public MekeSellRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        public List<Orders> GetAll(string key)
        {
            List<Orders> ordersList = new List<Orders>();
            string sql;

            try
            {
                if (key == null)
                    sql = @"SELECT      
		                          Orders.OrderId AS OrderId, Orders.OrderTag AS OrderTag, Orders.Status Status,
		                          Orders.PaymentMethod AS PaymentMethod, Orders.Date AS Date,
		                          Orders.TotalAmount AS TotalAmount,

		                          BarCodes.BarCodeId AS BarCodeId,
		                          
		                          Customers.CustomerId AS CustomerId,
		                          Customers.CustomerFullName AS CustomerFullName, Customers.Phone AS Phone,
		                          Customers.Email AS Email, Customers.Address AS Address,
		                          
		                          Products.ProductId AS ProId, Products.ProductIdTag AS ProductIdTag,
		                          Products.ProductName AS ProductName, Products.ProductStatus AS ProductStatus,
		                          Products.ProductPerUnitPrice AS ProductPerUnitPrice, Products.ProductUnitStock AS ProductUnitStock,
		                          Products.ProductMSRP AS ProductMSRP, Products.ProductDiscountRate AS ProductDiscountRate,
		                          
		                          Users.UserId AS UserId,
		                          Users.FirstName AS FirstName, Users.Role AS Role,
		                          
		                          Brands.BrandName AS BrandName, Vendors.VendorName VendorName,
		                          ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
		                          SecondCategories.SecondCategoryName AS SecondCategoryName,
		                          MainCategories.MainCategoryName AS MainCategoryName
                                  FROM 
		                          Orders INNER JOIN
		                          Products ON Orders.ProductId = Products.ProductId INNER JOIN
                                  Customers ON Orders.CustomerId = Customers.CustomerId INNER JOIN
						          BarCodes ON Orders.BarCodeId = BarCodes.BarCodeId INNER JOIN
                                  Users ON Orders.UserId = Users.UserId INNER JOIN
                                  Brands ON Products.BrandId = Brands.BrandId INNER JOIN
                                  Vendors ON Brands.VendorId = Vendors.VendorId INNER JOIN
                                  ThirdCategories ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId INNER JOIN
                                  SecondCategories ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId INNER JOIN
						          MainCategories ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId ";
                else
                    sql = @"SELECT      
		                          Orders.OrderId AS OrderId, Orders.OrderTag AS OrderTag, Orders.Status Status,
		                          Orders.PaymentMethod AS PaymentMethod, Orders.Date AS Date,
		                          Orders.TotalAmount AS TotalAmount,

		                          BarCodes.BarCodeId AS BarCodeId,
		                          
		                          Customers.CustomerId AS CustomerId,
		                          Customers.CustomerFullName AS CustomerFullName, Customers.Phone AS Phone,
		                          Customers.Email AS Email, Customers.Address AS Address,
		                          
		                          Products.ProductId AS ProId, Products.ProductIdTag AS ProductIdTag,
		                          Products.ProductName AS ProductName, Products.ProductStatus AS ProductStatus,
		                          Products.ProductPerUnitPrice AS ProductPerUnitPrice, Products.ProductUnitStock AS ProductUnitStock,
		                          Products.ProductMSRP AS ProductMSRP, Products.ProductDiscountRate AS ProductDiscountRate,
		                          
		                          Users.UserId AS UserId,
		                          Users.FirstName AS FirstName, Users.Role AS Role,
		                          
		                          Brands.BrandName AS BrandName, Vendors.VendorName VendorName,
		                          ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
		                          SecondCategories.SecondCategoryName AS SecondCategoryName,
		                          MainCategories.MainCategoryName AS MainCategoryName
                                  FROM 
		                          Orders INNER JOIN
		                          Products ON Orders.ProductId = Products.ProductId INNER JOIN
                                  Customers ON Orders.CustomerId = Customers.CustomerId INNER JOIN
						          BarCodes ON Orders.BarCodeId = BarCodes.BarCodeId INNER JOIN
                                  Users ON Orders.UserId = Users.UserId INNER JOIN
                                  Brands ON Products.BrandId = Brands.BrandId INNER JOIN
                                  Vendors ON Brands.VendorId = Vendors.VendorId INNER JOIN
                                  ThirdCategories ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId INNER JOIN
                                  SecondCategories ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId INNER JOIN
						          MainCategories ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId 

                                  where SecondCategories.SecondCategoryName like '%" + key + "%' or MainCategories.MainCategoryName like '%" + key + "%' ; ";

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

            //Products
            orders.ProductName = row["ProductName"].ToString(); 
            orders.ProductId = Convert.ToInt32(row["ProId"].ToString());
            orders.ProductIdTag = row["ProductIdTag"].ToString();
            orders.ProductUnitStock = Convert.ToInt32(row["ProductUnitStock"].ToString());
            orders.ProductPerUnitPrice = Convert.ToDouble(row["ProductPerUnitPrice"].ToString());
            orders.ProductDiscountRate = Convert.ToDouble(row["ProductDiscountRate"].ToString());
            orders.ProductMSRP = Convert.ToDouble(row["ProductMSRP"].ToString());
            orders.ProductStatus = row["ProductStatus"].ToString();

            //Users
            orders.UserId = Convert.ToInt32(row["UserId"].ToString());
            orders.FirstName = row["FirstName"].ToString();
            orders.Role = row["Role"].ToString();

            //Customer
            orders.CustomerId = Convert.ToInt32(row["CustomerId"].ToString());
            orders.CustomerFullName = row["CustomerFullName"].ToString();
            orders.Email = row["Email"].ToString();
            orders.Phone = row["Phone"].ToString();
            orders.Address = row["Address"].ToString();

            //Order
            orders.OrderId = Convert.ToInt32(row["OrderId"].ToString());
            orders.OrderTag = row["OrderTag"].ToString();
            orders.Date = Convert.ToDateTime(row["Date"].ToString());
            orders.TotalAmount = Convert.ToDouble(row["TotalAmount"].ToString());
            orders.Status = row["Status"].ToString();

            //BarCode
            orders.BarCodeId = Convert.ToInt32(row["BarCodeId"].ToString());

            //BrandName
            orders.BrandName = row["BrandName"].ToString();

            //VendorName
            orders.VendorName = row["VendorName"].ToString();

            //ThirdCat
            orders.ThirdCategoryName = row["ThirdCategoryName"].ToString();

            //SecondCate
            orders.SecondCategoryName = row["SecondCategoryName"].ToString();


            return orders;
        }

    }
}
