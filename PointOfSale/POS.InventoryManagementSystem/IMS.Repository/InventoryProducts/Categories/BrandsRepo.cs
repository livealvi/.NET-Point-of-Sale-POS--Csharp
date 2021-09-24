using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    
    public class BrandsRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public BrandsRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<Brands> GetAll(string key)
        {
            List<Brands> brandsList = new List<Brands>();

            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT
                                    Brands.BrandId AS BrandId, Brands.BrandTag AS BrandTag, Brands.BrandName As BrandName,
                                    Brands.BrandDescription AS BrandDisc, Brands.BrandStatus AS BrandStatus,
                                    Brands.BrandImage AS BrandImage, Vendors.VendorId AS VendorId, Vendors.VendorName AS VendorName
                                    FROM Brands
                                    LEFT JOIN Vendors
			                        ON Brands.VendorId = Vendors.VendorId;";
                else
                    sql = @"SELECT
                                    Brands.BrandId AS BrandId, Brands.BrandTag AS BrandTag, Brands.BrandName As BrandName,
                                    Brands.BrandDescription AS BrandDisc, Brands.BrandStatus AS BrandStatus,
                                    Brands.BrandImage AS BrandImage, Vendors.VendorId AS VendorId, Vendors.VendorName AS VendorName
                                    FROM Brands
                                    LEFT JOIN Vendors
			                        ON Brands.VendorId = Vendors.VendorId
                                    where Brands.BrandName like '%" + key + "%' or Brands.BrandStatus like '%" + key + "%' or " + 
                                    " Vendors.VendorName like '%" + key + "%'; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Brands br = this.ConvertToEntity(dt.Rows[x]);
                    brandsList.Add(br);
                    x++;
                }
                return brandsList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Brands ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var brand = new Brands();
            brand.BrandId = Convert.ToInt32(row["BrandId"].ToString());
            brand.BrandTag = row["BrandTag"].ToString();
            brand.BrandName = row["BrandName"].ToString();
            brand.BrandDescription = row["BrandDisc"].ToString();
            brand.BrandStatus = row["BrandStatus"].ToString();
            //brand.BrandImage = Convert.ToDouble(row["pMSRP"].ToString());
            brand.VendorId = Convert.ToInt32(row["VendorId"].ToString());
            brand.VendorName = row["VendorName"].ToString();
            return brand;
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
                list.Add(ConvertToBrandList(row));
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

        private Brands ConvertToBrandList(DataRow row)
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

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select BrandId from Brands where BrandId=" + id);

                Debug.WriteLine(ds.Tables[0].Rows.Count);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                return false;
            }
        }

        //save - Brands
        public bool Save(Brands br)
        {
            try
            {
                var sql = @"insert into Brands (BrandName, VendorId, BrandDescription, BrandStatus)
                                values ('" + br.BrandName + "' , '" + br.VendorId + "' , '" + br.BrandDescription + "' ,'" + br.BrandStatus + "');";

                var rowCount = this.iDB.ExecuteDMLQuery(sql);

                if (rowCount == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }

        //update - Brands
        public bool UpdateProduct(Brands br)
        {
            try
            {
                string sql = @"update Brands set BrandName='" + br.BrandName + "' , VendorId='" + br.VendorId + "'," +
                             "BrandDescription='" + br.BrandDescription + "'," +
                             "BrandStatus='" + br.BrandStatus + "' where BrandId='" + br.BrandId + "' ";

                int count = this.iDB.ExecuteDMLQuery(sql);

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw;
            }
        }

        //delete - Brands
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from Brands where BrandId ='" + id + "';";
                var dataTable = this.iDB.ExecuteDMLQuery(sql);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
                throw;
            }
        }
    }
}
