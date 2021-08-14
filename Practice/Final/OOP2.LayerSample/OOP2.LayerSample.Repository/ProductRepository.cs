using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2.LayerSample.Data;
using OOP2.LayerSample.Entity;

namespace OOP2.LayerSample.Repository
{
    public class ProductRepository
    {
        private DataAccess Da {get; set;}

        public ProductRepository()
        {
            this.Da = new DataAccess();
        }

        //view and search
        public List<Product> GetAll(string key)
        {
            List<Product> productList = new List<Product>();
            string sql;

            try
            {
                if (key == null)
                    sql = @"select * from ProductInfo;";
                else
                    sql = @"select * from ProductInfo where PName like '%" + key +"%' or AppId like '%"+ key +"%';";
                var dt = this.Da.ExecuteQueryTable(sql);

                for (int ax = 0; ax < dt.Rows.Count; ax++)
                {
                    Product p = this.ConvertToEntity(dt.Rows[ax]);
                    productList.Add(p);
                }
                return productList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        //save
        public bool Save(Product p)
        {
            try
            {
                var sql= @"insert into ProductInfo values('" + p.AppId+ "' , '" +p.PName +"' ," +
                          "'" + p.Quantity+ "' ,'" + p.UnitPrice+ "');";
                  
                var rowCount = this.Da.ExecuteDMLQuery(sql);

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
        
        //delete
        public void Delete(string id)
        {
            string sql;
            try
            {
                sql = "delete from ProductInfo where Id = '" + id + "';";
                var dt = this.Da.ExecuteDMLQuery(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private Product ConvertToEntity(DataRow row)
        {
            if (row == null)
                return null;

            var product = new Product();
            product.Id = Convert.ToInt32(row["Id"].ToString());
            product.AppId = row["AppId"].ToString();
            product.PName = row["PName"].ToString();
            product.Quantity = Convert.ToInt32(row["Quantity"].ToString());
            product.UnitPrice = Convert.ToDouble(row["UnitPrice"].ToString());

            return product;
        }

    }
}
