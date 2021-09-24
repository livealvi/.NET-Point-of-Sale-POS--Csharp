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
    public class MainCategoriesRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public MainCategoriesRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        

        //view & search
        public List<MainCategories> GetAll(string key)
        {
            List<MainCategories> mainCategoriesList = new List<MainCategories>();

            string sql;
            try
            {
                if (key == null)
                    sql =
                        @"SELECT MainCategories.MainCategoryId AS MainCategoryId, MainCategories.MainCategoryName AS MainCategoryName
                          FROM MainCategories";
                else
                    sql = @"SELECT MainCategories.MainCategoryId AS MainCategoryId, MainCategories.MainCategoryName AS MainCategoryName
                          FROM MainCategories

                          where MainCategories.MainCategoryId like '%" + key + "%' or MainCategories.MainCategoryName like '%" + key + "%' ; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    MainCategories sc = this.ConvertToEntity(dt.Rows[x]);
                    mainCategoriesList.Add(sc);
                    x++;
                }
                return mainCategoriesList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private MainCategories ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var mainCate = new MainCategories();
            mainCate.MainCategoryId = Convert.ToInt32(row["MainCategoryId"].ToString());
            mainCate.MainCategoryName = row["MainCategoryName"].ToString();
            return mainCate;
        }

        //LoadComboBox
        public DataTable LoadComboMainCategoryName()
        {
            string sql;
            try
            {
                sql = @"SELECT MainCategoryId, MainCategoryName FROM MainCategories";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<MainCategories> GetMainCategoriesList()
        {
            DataTable dt = LoadComboMainCategoryName();

            List<MainCategories> list = new List<MainCategories>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToMainCateList(row));
            }
            return list;
        }

        public int GetMainCategoryId(string mainCateName)
        {
            List<MainCategories> list = GetMainCategoriesList();

            foreach (MainCategories mc in list)
            {
                if (mc.MainCategoryName == mainCateName)
                {
                    return mc.MainCategoryId;
                }
            }
            return 0;
        }

        private MainCategories ConvertToMainCateList(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var m = new MainCategories();
            m.MainCategoryName = row["MainCategoryName"].ToString();
            m.MainCategoryId = Convert.ToInt32(row["MainCategoryId"].ToString());
            return m;
        }

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select MainCategoryId from MainCategories where MainCategoryId=" + id);

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

        //save - MainCategory
        public bool Save(MainCategories mc)
        {
            try
            {
                var sql = @"insert into MainCategories (MainCategoryName)
                                values ('" + mc.MainCategoryName + "');";

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

        //update - MainCategory
        public bool UpdateProduct(MainCategories mc)
        {
            try
            {
                string sql = @"update MainCategories set MainCategoryName='" + mc.MainCategoryName + "' where MainCategoryId='" + mc.MainCategoryId + "';";

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

        //delete - MainCategory
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from MainCategories where MainCategoryId ='" + id + "';";
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
