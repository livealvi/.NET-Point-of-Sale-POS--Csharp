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
    public class ThirdCategoriesRepo
    {
        private InventoryDBDataAccess iDB{get; set;}

        public ThirdCategoriesRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<ThirdCategories> GetAll(string key)
        {
            List<ThirdCategories> thirdCategoriesList = new List<ThirdCategories>();

            string sql;
            try
            {
                if (key == null)
                    sql =
                        @"SELECT ThirdCategories.ThirdCategoryId AS ThirdCategoryId, ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
                          ThirdCategories.ThirdCategoryImage AS ThirdCategoryImage, SecondCategories.SecondCategoryId AS SecondCategoryId, 
                          SecondCategories.SecondCategoryName AS SecondCategoryName
                          FROM ThirdCategories
				          LEFT JOIN SecondCategories
                          ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId";
                else
                    sql = @"SELECT ThirdCategories.ThirdCategoryId AS ThirdCategoryId, ThirdCategories.ThirdCategoryName AS ThirdCategoryName,
                          ThirdCategories.ThirdCategoryImage AS ThirdCategoryImage, SecondCategories.SecondCategoryId AS SecondCategoryId, 
                          SecondCategories.SecondCategoryName AS SecondCategoryName
                          FROM ThirdCategories
				          LEFT JOIN SecondCategories
                          ON ThirdCategories.SecondCategoryId = SecondCategories.SecondCategoryId
                          where ThirdCategories.ThirdCategoryName like '%" + key + "%' or SecondCategories.SecondCategoryName like '%" + key + "%' ; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    ThirdCategories th = this.ConvertToEntity(dt.Rows[x]);
                    thirdCategoriesList.Add(th);
                    x++;
                }
                return thirdCategoriesList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private ThirdCategories ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var thirdCate = new ThirdCategories();
            thirdCate.ThirdCategoryId = Convert.ToInt32(row["ThirdCategoryId"].ToString());
            thirdCate.ThirdCategoryName = row["ThirdCategoryName"].ToString();
            thirdCate.SecondCategoryId = Convert.ToInt32(row["SecondCategoryId"].ToString());
            thirdCate.SecondCategoryName = row["SecondCategoryName"].ToString();
            return thirdCate;
        }

        //LoadComboBox
        public DataTable LoadComboThirdCategoryName()
        {
            string sql;
            try
            {
                sql = @"SELECT ThirdCategoryId , ThirdCategoryName FROM ThirdCategories";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<ThirdCategories> GetThirdCategoryList()
        {
            try
            {
                DataTable dt = LoadComboThirdCategoryName();

                List<ThirdCategories> list = new List<ThirdCategories>();

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(ConvertToThirdCateList(row));
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        public int GetThirdCateId(string thirdCateName)
        {
            try
            {
                List<ThirdCategories> list = GetThirdCategoryList();

                foreach (ThirdCategories thirdCate in list)
                {
                    if (thirdCate.ThirdCategoryName == thirdCateName)
                    {
                        return thirdCate.ThirdCategoryId;
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private ThirdCategories ConvertToThirdCateList(DataRow row)
        {
            try
            {
                if (row == null)
                {
                    return null;
                }

                var thC = new ThirdCategories();
                thC.ThirdCategoryName = row["ThirdCategoryName"].ToString();
                thC.ThirdCategoryId = Convert.ToInt32(row["ThirdCategoryId"].ToString());
                return thC;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select ThirdCategoryId from ThirdCategories where ThirdCategoryId=" + id);

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

        //save - ThirdCategory
        public bool Save(ThirdCategories thc)
        {
            try
            {
                var sql = @"insert into ThirdCategories (ThirdCategoryName, SecondCategoryId)
                                values ('" + thc.ThirdCategoryName + "' , '" + thc.SecondCategoryId + "');";

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

        //update - ThirdCategory
        public bool UpdateProduct(ThirdCategories thc)
        {
            try
            {
                string sql = @"update ThirdCategories set ThirdCategoryName='" + thc.ThirdCategoryName + "' , SecondCategoryId='" + thc.SecondCategoryId + "' where ThirdCategoryId='" + thc.ThirdCategoryId + "'";

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

        //delete - ThirdCategory
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from ThirdCategories where ThirdCategoryId ='" + id + "';";
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
