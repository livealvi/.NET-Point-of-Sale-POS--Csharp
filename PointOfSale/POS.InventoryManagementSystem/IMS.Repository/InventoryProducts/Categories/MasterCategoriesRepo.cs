using IMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Entity;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    public class MasterCategoriesRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public MasterCategoriesRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        public string GetMainCate()
        {
            return iDB.GetSingleData("  select sum(MainCategoryId) as id from MainCategories ", "Id");
        }

        public string GetSecCate()
        {
            return iDB.GetSingleData("  select sum(SecondCategoryId) as id from SecondCategories ", "Id");
        }

        public string GetThCate()
        {
            return iDB.GetSingleData("  select sum(ThirdCategoryId) as id from ThirdCategories ", "Id");
        }

        public string GetVN()
        {
            return iDB.GetSingleData("  select sum(VendorId) as id from Vendors ", "Id");
        }

        public string GetBR()
        {
            return iDB.GetSingleData("  select sum(BrandId) as id from Brands ", "Id");
        }



        public List<Products> GetAll(string key)
        {
            List<Products> productsList = new List<Products>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT
                                    Products.ProductName AS ProductName, Brands.BrandName AS BrandName,
                                    Vendors.VendorName AS VendorName, ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
                                    SecondCategories.SecondCategoryName AS SecondCategoryName,
                                    MainCategories.MainCategoryName AS MainCategoryName
                                    FROM Products
					                left join Brands 
					                Brands ON Products.BrandId = Brands.BrandId 
					                left join Vendors
                                    Vendors ON Brands.VendorId = Vendors.VendorId
						            left join ThirdCategories
                                    ThirdCategories ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId
						            left join SecondCategories
                                    SecondCategories ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId
						            left join MainCategories
                                    MainCategories ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId";

                else
                    sql = @"SELECT
                                    Products.ProductName AS ProductName, Brands.BrandName AS BrandName,
                                    Vendors.VendorName AS VendorName, ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
                                    SecondCategories.SecondCategoryName AS SecondCategoryName,
                                    MainCategories.MainCategoryName AS MainCategoryName
                                    FROM Products
					                left join Brands 
					                Brands ON Products.BrandId = Brands.BrandId 
					                left join Vendors
                                    Vendors ON Brands.VendorId = Vendors.VendorId
						            left join ThirdCategories
                                    ThirdCategories ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId
						            left join SecondCategories
                                    SecondCategories ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId
						            left join MainCategories
                                    MainCategories ON SecondCategories.MainCategoryId = MainCategories.MainCategoryId

				                    where Products.ProductName like '%" + key + "%' or Brands.BrandName like '%" + key + "%' or   Vendors.VendorName like '%" + key + "%' " +
                                    " or ThirdCategories.ThirdCategoryName like '%" + key + "%' or SecondCategories.SecondCategoryName like '%" + key + "%' " +
                                    " or  ThirdCategories.ThirdCategoryName like '%" + key + "%' or  MainCategories.MainCategoryName like '%" + key + "%';";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Products px = ConvertToEntity(dt.Rows[x++]);
                    productsList.Add(px);
                    x++;
                }
                return productsList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Products ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var products = new Products();
            products.ProductName = row["ProductName"].ToString();
            products.BrandName = row["BrandName"].ToString();
            products.VendorName = row["VendorName"].ToString();
            products.ThirdCategoryName = row["ThirdCategoryName"].ToString();
            products.SecondCategoryName = row["SecondCategoryName"].ToString();
            products.MainCategoryName = row["MainCategoryName"].ToString();
            return products;
        }
    }
}
