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
    
    public class BrandsRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public BrandsRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }



        //LoadComboBox
        public DataTable LoadComboBrandName()
        {
            string sql;
            try
            {
                sql = @"SELECT BrandId , BrandName FROM Brands";
                return this.iDB.ExecuteQueryTable(sql);
                
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Brands> GetBrandsList()
        {
            DataTable dt = LoadComboBrandName();

            List<Brands> list = new List<Brands>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToEntity(row));
            }

            return list;
        }

        public int GetBrandId(string brandName)
        {
            List<Brands> list = GetBrandsList();

            foreach (Brands brand in list)
            {
                if (brand.BrandName == brandName)
                {
                    return brand.BrandId;
                }
            }

            return 0;
        }


        //private Brands ConvertToEntityBrandName(DataRow row)
        //{
        //    if (row == null)
        //    {
        //        return null;
        //    }

        //    var product = new Products();
        //    product.ProductId = Convert.ToInt32(row["pID"].ToString());
        //    product.ProductIdTag = row["pTag"].ToString();
        //    product.ProductName = row["pName"].ToString();
        //    product.BrandId = Convert.ToInt32(row["bId"].ToString());
        //    product.ProductDescription = row["ProductDescription"].ToString();
        //    product.ProductQuantityPerUnit = Convert.ToDouble(row["ProductQuantityPerUnit"]);
        //    product.ProductPerUnitPrice = Convert.ToDouble(row["ProductPerUnitPrice"]);
        //    product.ProductMSRP = Convert.ToDouble(row["ProductMSRP"]);
        //    product.ProductStatus = row["ProductStatus"].ToString();
        //    product.ProductDiscountRate = Convert.ToDouble(row["ProductDiscountRate"]);
        //    product.ProductSize = Convert.ToDouble(row["ProductSize"]);
        //    product.ProductColor = row["ProductColor"].ToString();
        //    //product.ProductPictures = new[] { Convert.ToByte(row["ProductPictures"].ToString()) };
        //    product.ProductWeight = Convert.ToDouble(row["ProductWeight"]);
        //    product.ProductUnitStock = row["ProductUnitStock"].ToString();

        //    return product;
        //}

        //view & search
        //public List<Brands> GetAll(string key)
        //{
        //    List<Brands> productList = new List<Brands>();
        //    string sql;

        //    try
        //    {
        //        if (key == null)
        //            sql = @"SELECT Products.ProductId AS pID, Products.ProductIdTag AS pTag, Products.ProductName AS pName, Brands.BrandName AS bN, Products.ProductDescription AS pDisc, Products.ProductQuantityPerUnit AS pQP, 
        //          Products.ProductMSRP AS pMSRP, Products.ProductPerUnitPrice AS pPUP, Products.ProductStatus AS pS, Products.ProductDiscountRate AS pD, Products.ProductSize AS pSize, Products.ProductColor AS pC, 
        //          Products.ProductWeight AS pW, Products.ProductUnitStock AS pUS
        //            FROM     Brands INNER JOIN
        //          Products ON Brands.BrandId = Products.BrandId";
        //        else
        //            sql = @"SELECT Products.ProductId AS pId, ProductIdTag, Products.ProductName AS pName, Brands.BrandName AS bName, ProductDescription, ProductQuantityPerUnit, ProductPerUnitPrice, 
        //          ProductMSRP, ProductStatus, ProductDiscountRate, ProductSize, ProductColor, ProductWeight, ProductUnitStock
        //          FROM Products INNER JOIN
        //          Brands ON Products.BrandId = Brands.BrandId ;";
        //        var dt = this.iDB.ExecuteQueryTable(sql);

        //        for (int ax = 0; ax < dt.Rows.Count; ax++)
        //        {
        //            Products p = this.ConvertToEntity(dt.Rows[ax]);
        //            productList.Add(p);
        //        }

        //        //int x = 0;
        //        //while (x < dataTable.Rows.Count)
        //        //{
        //        //    Products pro = this.ConvertToEntity(dataTable.Rows[x]);
        //        //    productList.Add(pro);
        //        //    x++;
        //        //}
        //        return productList;
        //    }

        //    catch (Exception e)
        //    {
        //        return null;
        //        throw;
        //    }
        //}

        //save
        //public bool Save(Products pro)
        //{
        //    try
        //    {
        //        var sql = @"";

        //        var rowCount = this.iDB.ExecuteDMLQuery(sql);

        //        if (rowCount == 1)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //        throw;
        //    }
        //}

        //delete
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



        private Brands ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var b = new Brands();
            
            b.BrandName = row["BrandName"].ToString();
            b.BrandId = Convert.ToInt32(row["BrandId"].ToString());
            return b;
        }


    }
}
