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
    public class MakeSalesRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public MakeSalesRepo()
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
                    sql = @"select p.ProductId as 'ProductId', p.ProductIdTag as 'ProductIdTag', p.ProductName as 'ProductName',
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
                    sql = @"select p.ProductId as ProductId, p.ProductIdTag as ProductIdTag, p.ProductName as ProductName,
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
                                

                                  where sc.SecondCategoryName like '%" + key + "%' or tc.ThirdCategoryName like '%" + key + "%' or " +
                          "b.BrandName like '%" + key + "%' or v.VendorName like '%" + key + "%' or  v.ProductId like '%" + key + "%' or " +
                          "p.ProductIdTag like '%" + key + "%' or p.ProductStatus like '%" + key + "%' or p.ProductPerUnitPrice like '%" + key + "%' or " +
                          "p.ProductUnitStock like '%" + key + "%' or p.ProductMSRP like '%" + key + "%' or p.ProductDiscountRate like '%" + key + "%' or " +
                          "p.ProductName like '%" + key + "%' ";

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
            orders.ProductId = Convert.ToInt32(row["ProductId"].ToString());
            orders.ProductIdTag = row["ProductIdTag"].ToString();
            orders.ProductUnitStock = Convert.ToInt32(row["ProductUnitStock"].ToString());
            orders.ProductPerUnitPrice = Convert.ToDouble(row["ProductPerUnitPrice"].ToString());
            orders.ProductDiscountRate = Convert.ToDouble(row["ProductDiscountRate"].ToString());
            orders.ProductMSRP = Convert.ToDouble(row["ProductMSRP"].ToString());
            orders.ProductStatus = row["ProductStatus"].ToString();

            //Users
            //orders.UserId = Convert.ToInt32(row["UserId"].ToString());
            //orders.FirstName = row["FirstName"].ToString();
            //orders.Role = row["Role"].ToString();

            ////Customer
            //orders.CustomerId = Convert.ToInt32(row["CustomerId"].ToString());
            //orders.CustomerFullName = row["CustomerFullName"].ToString();
            //orders.Email = row["Email"].ToString();
            //orders.Phone = row["Phone"].ToString();
            //orders.Address = row["Address"].ToString();

            ////Order
            //orders.OrderId = Convert.ToInt32(row["OrderId"].ToString());
            //orders.OrderTag = row["OrderTag"].ToString();
            //orders.Date = Convert.ToDateTime(row["Date"].ToString());
            //orders.TotalAmount = Convert.ToDouble(row["TotalAmount"].ToString());
            //orders.Status = row["Status"].ToString();

            //BarCode
            //orders.BarCodeId = Convert.ToInt32(row["BarCodeId"].ToString());

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
