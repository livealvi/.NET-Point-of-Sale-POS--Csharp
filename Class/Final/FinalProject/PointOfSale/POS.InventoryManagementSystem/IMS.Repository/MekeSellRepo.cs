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
		                        
		                        Customers.CustomerFullName AS CustomerFullName, Customers.Phone AS Phone,
		                        Customers.Email AS Email, Customers.Address AS Address,
		                        
		                        Products.ProductId AS ProId, Products.ProductIdTag AS ProductIdTag,
		                        Products.ProductName AS ProductName, Products.ProductStatus AS ProductStatus,
		                        Products.ProductPerUnitPrice AS ProductPerUnitPrice,
		                        Products.ProductMSRP AS ProductMSRP, Products.ProductDiscountRate AS ProductDiscountRate,
		                        
		                        Users.FirstName AS FirstName, Users.Role AS Role,
		                        
		                        Brands.BrandName AS BrandName, Vendors.VendorName VendorName,
		                        ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
		                        SecondCategories.SecondCategoryName AS SecondCategoryName,
		                        MainCategories.MainCategoryName AS MainCategoryName
                                FROM 
		                        Orders INNER JOIN
		                        Products ON Orders.ProductId = Products.ProductId INNER JOIN
                                Customers ON Orders.CustomerId = Customers.CustomerId INNER JOIN
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
		                        
		                        Customers.CustomerFullName AS CustomerFullName, Customers.Phone AS Phone,
		                        Customers.Email AS Email, Customers.Address AS Address,
		                        
		                        Products.ProductId AS ProId, Products.ProductIdTag AS ProductIdTag,
		                        Products.ProductName AS ProductName, Products.ProductStatus AS ProductStatus,
		                        Products.ProductPerUnitPrice AS ProductPerUnitPrice,
		                        Products.ProductMSRP AS ProductMSRP, Products.ProductDiscountRate AS ProductDiscountRate,
		                        
		                        Users.FirstName AS FirstName, Users.Role AS Role,
		                        
		                        Brands.BrandName AS BrandName, Vendors.VendorName VendorName,
		                        ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
		                        SecondCategories.SecondCategoryName AS SecondCategoryName,
		                        MainCategories.MainCategoryName AS MainCategoryName
                                FROM 
		                        Orders INNER JOIN
		                        Products ON Orders.ProductId = Products.ProductId INNER JOIN
                                Customers ON Orders.CustomerId = Customers.CustomerId INNER JOIN
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


            //secCate.SecondCategoryId = Convert.ToInt32(row["SecondCategoryId"].ToString());
            //secCate.SecondCategoryName = row["SecondCategoryName"].ToString();
            secCate.MainCategoryId = Convert.ToInt32(row["MainCategoryId"].ToString());
            secCate.MainCategoryName = row["MainCategoryName"].ToString();

            return secCate;
        }

    }
}
