using IMS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IMS.Entity;

namespace IMS.Repository
{
    public class ProductsCategoriesMapRepo
    {
        private InventoryDBDataAccess iDB { get; set; }

        public ProductsCategoriesMapRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<Products_Categories_Map> GetAll(string key)
        {
            List<Products_Categories_Map> proCateMapList = new List<Products_Categories_Map>();
            string sql;
            //Products.ProductPictures AS pPictures,
            try
            {
                if (key == null)
                    sql = @"SELECT Products.ProductId AS pID, Products.ProductIdTag AS pTag, Products.ProductName AS pName, Brands.BrandName AS pBrandName, Products.ProductStatus AS pStatus, Products.ProductMSRP AS pMSRP, 
                  Products.ProductPerUnitPrice AS pPerUnPrice, Products.ProductQuantityPerUnit AS pQuaPerUn, Products.ProductDiscountRate AS pDisRate, Products.ProductSize AS pSize, Products.ProductColor AS pColor, 
                   Products.ProductWeight AS pWeight, Products.ProductUnitStock AS pUnStock, Products.ProductDescription AS pDisc, Vendors.VendorName AS pVendor, 
                  ThirdCategories.ThirdCategoryName AS pThCate, SecondCategories.SecondCategoryName AS pScCate, MainCategories.MainCategoryName AS pMnCate
                   FROM     Products_Categories_Map INNER JOIN
                  Products ON Products_Categories_Map.ProductId = Products.ProductId INNER JOIN
                  Brands ON Products_Categories_Map.BrandId = Brands.BrandId AND Products.BrandId = Brands.BrandId INNER JOIN
                  Vendors ON Products_Categories_Map.VendorId = Vendors.VendorId AND Brands.VendorId = Vendors.VendorId INNER JOIN
                  ThirdCategories ON Products_Categories_Map.ThirdCategoryId = ThirdCategories.ThirdCategoryId AND Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId INNER JOIN
                  SecondCategories ON Products_Categories_Map.SecondCategoryId = SecondCategories.SecondCategoryId AND ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId INNER JOIN
                  MainCategories ON Products_Categories_Map.MainCategoryId = MainCategories.MainCategoryId AND SecondCategories.MainCategoryId = MainCategories.MainCategoryId";

                else
                    sql = @"SELECT Products.ProductId AS pID, Products.ProductIdTag AS pTag, Products.ProductName AS pName, Brands.BrandName AS pBrandName, Products.ProductStatus AS pStatus, Products.ProductMSRP AS pMSRP, 
                  Products.ProductPerUnitPrice AS pPerUnPrice, Products.ProductQuantityPerUnit AS pQuaPerUn, Products.ProductDiscountRate AS pDisRate, Products.ProductSize AS pSize, Products.ProductColor AS pColor, 
                   Products.ProductWeight AS pWeight, Products.ProductUnitStock AS pUnStock, Products.ProductDescription AS pDisc, Vendors.VendorName AS pVendor, 
                  ThirdCategories.ThirdCategoryName AS pThCate, SecondCategories.SecondCategoryName AS pScCate, MainCategories.MainCategoryName AS pMnCate
                   FROM     Products_Categories_Map INNER JOIN
                  Products ON Products_Categories_Map.ProductId = Products.ProductId INNER JOIN
                  Brands ON Products_Categories_Map.BrandId = Brands.BrandId AND Products.BrandId = Brands.BrandId INNER JOIN
                  Vendors ON Products_Categories_Map.VendorId = Vendors.VendorId AND Brands.VendorId = Vendors.VendorId INNER JOIN
                  ThirdCategories ON Products_Categories_Map.ThirdCategoryId = ThirdCategories.ThirdCategoryId AND Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId INNER JOIN
                  SecondCategories ON Products_Categories_Map.SecondCategoryId = SecondCategories.SecondCategoryId AND ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId INNER JOIN
                  MainCategories ON Products_Categories_Map.MainCategoryId = MainCategories.MainCategoryId AND SecondCategories.MainCategoryId = MainCategories.MainCategoryId

				  where Products.ProductIdTag like '%" + key + "%' or Products.ProductName like '%" + key + "%' or  Brands.BrandName like '%" + key + "%' or Products.ProductMSRP like '%" + key + "%' or Vendors.VendorName like '%" + key + "%' or  ThirdCategories.ThirdCategoryName like '%" + key + "%' or  SecondCategories.SecondCategoryName like '%" + key + "%' or  MainCategories.MainCategoryName like '%" + key + "%';";
                
                var dt = this.iDB.ExecuteQueryTable(sql);

                for (int ax = 0; ax < dt.Rows.Count; ax++)
                {
                    Products_Categories_Map pmc = ConvertToEntity(dt.Rows[ax]);
                    proCateMapList.Add(pmc);
                }
                return proCateMapList;

                //for (int ax = 0; ax < dt.Rows.Count; ax++)
                //{
                //    Products_Categories_Map pcm = this.ConvertToEntity(dt.Rows[ax]);
                //    proCateMapList.Add(pcm);
                //} 

                //int x = 0;
                //while (x < dataTable.Rows.Count)
                //{
                //    ProductsCategoriesMap proDe = this.ConvertToEntity(dataTable.Rows[x]);
                //    proCateMapList.Add(proDe);
                //    x++;
                //}
                //return proCateMapList;
            }

            catch (Exception e)
            {
                return null;
                throw;
            }
        }



        

        //save
        public bool Save(Products_Categories_Map ins)
        {
            try
            {
                var sql = @"insert into Products (ProductName) values ('" + ins.ProductName + "' ,'" + ins.BrandId + "' , '" + ins.ProductDescription + "' ,'" + ins.ProductQuantityPerUnit + "' ,'" + ins.ProductPerUnitPrice + "' ,'" + ins.ProductMSRP + "' ,'" + ins.ProductStatus + "' ,'" + ins.ProductDiscountRate + "' ,'" + ins.ProductSize + "' ,'" + ins.ProductColor + "' ,'" + ins.ProductWeight + "' ,'" + ins.ProductUnitStock + "');";

                var rowCount = this.iDB.ExecuteDMLQuery(sql);

                if (rowCount == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        ////delete
        //public void Delete(string id)
        //{
        //    string sql;

        //    try
        //    {
        //        sql = @"";
        //        var dataTable = this.iDB.ExecuteDMLQuery(sql);
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        

        private Products_Categories_Map ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var proCateMap = new Products_Categories_Map();

            proCateMap.ProductId = Convert.ToInt32(row["pID"].ToString());
            proCateMap.ProductIdTag = row["pTag"].ToString();
            proCateMap.ProductName = row["pName"].ToString();
            proCateMap.BrandName = row["pBrandName"].ToString();
            proCateMap.ProductStatus = row["pStatus"].ToString();
            proCateMap.ProductMSRP = Convert.ToDouble(row["pMSRP"].ToString());
            proCateMap.ProductPerUnitPrice = Convert.ToDouble(row["pPerUnPrice"].ToString());
            proCateMap.ProductQuantityPerUnit = Convert.ToDouble(row["pQuaPerUn"].ToString());
            proCateMap.ProductDiscountRate = Convert.ToDouble(row["pDisRate"].ToString());
            proCateMap.ProductSize = Convert.ToDouble(row["pSize"].ToString());
            proCateMap.ProductColor = row["pColor"].ToString();
            //proCateMas.ProductPictures = new[] { Convert.ToByte(row["pPictures"].ToString()) };
            proCateMap.ProductWeight = Convert.ToDouble(row["pWeight"].ToString());
            proCateMap.ProductUnitStock = row["pUnStock"].ToString();
            proCateMap.ProductDescription = row["pDisc"].ToString();
            proCateMap.VendorName = row["pVendor"].ToString();
            proCateMap.ThirdCategoryName = row["pThCate"].ToString();
            proCateMap.SecondCategoryName = row["pScCate"].ToString();
            proCateMap.MainCategoryName = row["pMnCate"].ToString();

            return proCateMap;
        }
    }
}
