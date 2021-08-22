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
    public class MainCategoriesRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }


        public MainCategoriesRepo()
        {
            this.iDB = new InventoryDBDataAccess();
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

    }
}
