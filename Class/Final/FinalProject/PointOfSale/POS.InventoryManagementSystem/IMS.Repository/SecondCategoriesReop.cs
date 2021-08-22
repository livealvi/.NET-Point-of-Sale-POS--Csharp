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
    public class SecondCategoriesReop
    {
        private InventoryDBDataAccess iDB{get; set;}

        public SecondCategoriesReop()
        {
            this.iDB = new InventoryDBDataAccess();
        }




        //LoadComboBox
        public DataTable LoadComboMainCategoryName()
        {
            string sql;
            try
            {
                sql = @"SELECT SecondCategoryId, SecondCategoryName FROM SecondCategories";
                return this.iDB.ExecuteQueryTable(sql);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<SecondCategories> GetSecondCategoriesList()
        {
            DataTable dt = LoadComboMainCategoryName();

            List<SecondCategories> list = new List<SecondCategories>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToSecondCateList(row));
            }

            return list;
        }

        public int GetSecondCategoryId(string mainCateName)
        {
            List<SecondCategories> list = GetSecondCategoriesList();

            foreach (SecondCategories sc in list)
            {
                if (sc.SecondCategoryName == mainCateName)
                {
                    return sc.SecondCategoryId;
                }
            }

            return 0;
        }

        private SecondCategories ConvertToSecondCateList(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var s = new SecondCategories();

            s.SecondCategoryName = row["SecondCategoryName"].ToString();
            s.SecondCategoryId = Convert.ToInt32(row["SecondCategoryId"].ToString());
            return s;
        }
    }
}
