using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity.InventoryProducts.Expense;

namespace IMS.Repository.InventoryProducts.Expense
{
    public class ExpenseRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public ExpenseRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        //view & search
        public List<Expenses> GetAll(string key)
        {
            List<Expenses> expensesList = new List<Expenses>();

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
                    Expenses ex = this.ConvertToEntity(dt.Rows[x]);
                    expensesList.Add(ex);
                    x++;
                }
                return expensesList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        public string GetLastWeekExpense()
        {
            return iDB.GetSingleData("select sum(ExpenseAmount) as sum from Expenses where ExpenseDate<GETDATE() and ExpenseDate>DATEADD(day,-8, GETDATE())", "sum");
        }

        private Expenses ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var expenses = new Expenses();
            expenses.ExpenseId = Convert.ToInt32(row["ExpenseId"].ToString());
            expenses.ExpenseName = row["ExpenseName"].ToString();
            expenses.ExpenseAmount = Convert.ToDouble(row["ExpenseAmount"].ToString());
            expenses.ExpenseDate = Convert.ToDateTime(row["ExpenseDate"].ToString());
            return expenses;
        }

    }
}
