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
    public class ProductsBrandViewRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public ProductsBrandViewRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        public List<Products> GetAll(string key)
        {
            List<Products> productList = new List<Products>();
            string sql;

            try
            {
                if (key == null)
                    sql = @"Select  Products.ProductId AS pID, Products.ProductIdTag AS pTag, Products.ProductName AS pName, Products.ProductStatus AS pStatus, Products.ProductMSRP AS pMSRP, 
                    Products.ProductPerUnitPrice AS pPerUnPrice, Products.ProductQuantityPerUnit AS pQuaPerUn, Products.ProductDiscountRate AS pDisRate, Products.ProductSize AS pSize, Products.ProductColor AS pColor, 
                    Products.ProductWeight AS pWeight, Products.ProductUnitStock AS pUnStock, Products.ProductDescription AS pDisc
                    FROM     Products";
                else
                    sql = @"SELECT Products.ProductId AS pID, Products.ProductIdTag AS pTag, Products.ProductName AS pName, Brands.BrandName AS pBrandName, Products.ProductStatus AS pStatus, Products.ProductMSRP AS pMSRP, 
                    Products.ProductPerUnitPrice AS pPerUnPrice, Products.ProductQuantityPerUnit AS pQuaPerUn, Products.ProductDiscountRate AS pDisRate, Products.ProductSize AS pSize, Products.ProductColor AS pColor, 
                    Products.ProductWeight AS pWeight, Products.ProductUnitStock AS pUnStock, Products.ProductDescription AS pDisc
                    FROM     Products INNER JOIN
                    Brands ON Products.BrandId = Brands.BrandId 
                    where Products.ProductIdTag like '%" + key + "%' or Products.ProductName like '%" + key + "%' or  Brands.BrandName like '%" + key + "%'; ";
                var dt = this.iDB.ExecuteQueryTable(sql);

                for (int ax = 0; ax < dt.Rows.Count; ax++)
                {
                    Products p = this.ConvertToEntity(dt.Rows[ax]);
                    productList.Add(p);
                }

                //int x = 0;
                //while (x < dataTable.Rows.Count)
                //{
                //    Products pro = this.ConvertToEntity(dataTable.Rows[x]);
                //    productList.Add(pro);
                //    x++;
                //}
                return productList;
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

            var product = new Products();
            product.ProductId = Convert.ToInt32(row["pID"].ToString());
            product.ProductIdTag = row["pTag"].ToString();
            product.ProductName = row["pName"].ToString();
            //product.BrandId = Convert.ToInt32(row["bId"].ToString());
            product.BrandName = row["pBrandName"].ToString();
            product.ProductStatus = row["pStatus"].ToString();
            product.ProductMSRP = Convert.ToDouble(row["pMSRP"].ToString());
            product.ProductPerUnitPrice = Convert.ToDouble(row["pPerUnPrice"].ToString());
            product.ProductQuantityPerUnit = Convert.ToDouble(row["pQuaPerUn"].ToString());
            product.ProductDiscountRate = Convert.ToDouble(row["pDisRate"].ToString());
            product.ProductSize = Convert.ToDouble(row["pSize"].ToString());
            product.ProductColor = row["pColor"].ToString();
            //proCateMas.ProductPictures = new[] { Convert.ToByte(row["pPictures"].ToString()) };
            product.ProductWeight = Convert.ToDouble(row["pWeight"].ToString());
            product.ProductUnitStock = Convert.ToInt32(row["pUnStock"].ToString());
            product.ProductDescription = row["pDisc"].ToString();

            return product;
        }

    }
}
