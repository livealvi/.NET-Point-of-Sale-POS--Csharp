using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    public class VendorsRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public VendorsRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<Vendors> GetAll(string key)
        {
            List<Vendors> vendorsList = new List<Vendors>();
            string sql;
            try
            {
                if (key == null)
                    sql =
                        @"SELECT
                                Vendors.VendorId AS VendorId, Vendors.VednorTag AS VendorTag, Vendors.VendorName AS VendorName,
                                Vendors.VendorDescription AS VendorDisc, Vendors.VendorStatus AS VendorStatus,
                                Vendors.RegisterDate AS RegisterDate,
                                Vendors.VendorImage AS VendorImage, ThirdCategories.ThirdCategoryId AS ThirdCateId,
                                ThirdCategories.ThirdCategoryName AS ThirdCateName
                                FROM Vendors
				                LEFT JOIN ThirdCategories
                                ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId";
                else
                    sql = @"SELECT
                                Vendors.VendorId AS VendorId, Vendors.VednorTag AS VendorTag, Vendors.VendorName AS VendorName,
                                Vendors.VendorDescription AS VendorDisc, Vendors.VendorStatus AS VendorStatus,
                                Vendors.RegisterDate AS RegisterDate,
                                Vendors.VendorImage AS VendorImage, ThirdCategories.ThirdCategoryId AS ThirdCateId,
                                ThirdCategories.ThirdCategoryName AS ThirdCateName
                                FROM Vendors
				                LEFT JOIN ThirdCategories
                                ON Vendors.ThirdCategoryId = ThirdCategories.ThirdCategoryId
                                where Vendors.VendorName like '%" + key + "%' or  Vendors.VendorStatus like '%" + key + "%' or " +
                              " ThirdCategories.ThirdCategoryName like '%" + key + "%'; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Vendors vn = this.ConvertToEntity(dt.Rows[x]);
                    vendorsList.Add(vn);
                    x++;
                }
                return vendorsList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Vendors ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var vendor = new Vendors();
            vendor.VendorId = Convert.ToInt32(row["VendorId"].ToString());
            vendor.VendorTag = row["VendorTag"].ToString();
            vendor.VendorName = row["VendorName"].ToString();
            vendor.VendorDescription = row["VendorDisc"].ToString();
            vendor.VendorStatus = row["VendorStatus"].ToString();
            //vendor.VendorImage = Convert.ToDouble(row["VendorImage"].ToString());
            vendor.ThirdCategoryId = Convert.ToInt32(row["ThirdCateId"].ToString());
            vendor.ThirdCategoryName = row["ThirdCateName"].ToString();
            vendor.RegisterDate = Convert.ToDateTime(row["RegisterDate"].ToString());
            return vendor;
        }

        //LoadComboBox
        public DataTable LoadComboVendorName()
        {
            string sql;
            try
            {
                sql = @"SELECT VendorId , VendorName FROM Vendors";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Vendors> GetVendorsList()
        {
            DataTable dt = LoadComboVendorName();

            List<Vendors> list = new List<Vendors>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToVendorList(row));
            }

            return list;
        }

        public int GetVendorId(string vendorName)
        {
            List<Vendors> list = GetVendorsList();

            foreach (Vendors vendor in list)
            {
                if (vendor.VendorName == vendorName)
                {
                    return vendor.VendorId;
                }
            }
            return 0;
        }

        private Vendors ConvertToVendorList(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var v = new Vendors();
            v.VendorName = row["VendorName"].ToString();
            v.VendorId = Convert.ToInt32(row["VendorId"].ToString());
            return v;
        }

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select VendorId from Vendors where VendorId=" + id);
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

        //save - vendor
        public bool Save(Vendors vr)
        {
            try
            {
                var sql = @"insert into Vendors (VendorName, ThirdCategoryId, VendorDescription, VendorStatus, RegisterDate)
                                values ('" + vr.VendorName + "' , '" + vr.ThirdCategoryId + "' , '" + vr.VendorDescription + "' , '" + vr.VendorStatus + "', '" + vr.RegisterDate + "');";

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

        //update - vendor
        public bool UpdateProduct(Vendors vr)
        {
            try
            {
                string sql = @"update Vendors set VendorName='" + vr.VendorName + "' , ThirdCategoryId='" + vr.ThirdCategoryId + "'," +
                             "VendorDescription=  '" + vr.VendorDescription + "', VendorStatus='" + vr.VendorStatus + "' , RegisterDate='" + vr.RegisterDate + "' where VendorId='" + vr.VendorId + "';";

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

        //delete - vendor
        public bool Delete(string id)
        {
            string sql;
            try
            {
                sql = @"delete from Vendors where VendorId ='" + id + "';";
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
