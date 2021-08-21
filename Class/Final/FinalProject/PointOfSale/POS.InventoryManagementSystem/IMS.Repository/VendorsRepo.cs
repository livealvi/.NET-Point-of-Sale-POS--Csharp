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
    public class VendorsRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public VendorsRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }











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
    }
}
