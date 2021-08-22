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
    public class ThirdCategoriesRepo
    {
        private InventoryDBDataAccess iDB{get; set;}

        public ThirdCategoriesRepo()
        {
            this.iDB = new InventoryDBDataAccess();
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
    }

}
