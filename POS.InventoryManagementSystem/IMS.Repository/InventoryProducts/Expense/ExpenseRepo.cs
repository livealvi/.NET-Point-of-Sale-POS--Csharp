using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        public string GetTodayExpense()
        {
            return iDB.GetSingleData("select sum(ExpenseAmount) as sum from Expenses where ExpenseDate=format(getdate(),'yyyy-MM-dd')", "sum");
        }

        public string GetLastWeekExpense()
        {
            return iDB.GetSingleData("select sum(ExpenseAmount) as sum from Expenses where ExpenseDate<GETDATE() and ExpenseDate>DATEADD(day,-8, GETDATE())", "sum");
        }
        public string GetLastMonth()
        {
            return iDB.GetSingleData("select sum(ExpenseAmount) as sum from Expenses where ExpenseDate<GETDATE() and ExpenseDate>DATEADD(day,-31, GETDATE())", "sum");
        }
        public string GetTotalExpense()
        {
            return iDB.GetSingleData("select  sum(ExpenseAmount) as TOTAL FROM Expenses ", "TOTAL");
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
                        @"SELECT ExpenseId, ExpenseName, ExpenseAmount, ExpenseDate
                                FROM Expenses";
                else
                    sql = @"SELECT ExpenseId, ExpenseName, ExpenseAmount, ExpenseDate
                                FROM Expenses

                          where ExpenseId like '%" + key + "%' or ExpenseName like '%" + key + "%' or ExpenseAmount like '%" + key + "%'" +
                          " or ExpenseDate like '%" + key + "%' ; ";

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

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select ExpenseId from Expenses where ExpenseId=" + id);

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

        //save - Expenses
        public bool Save(Expenses ex)
        {
            try
            {
                var sql = @"insert into Expenses (ExpenseName, ExpenseAmount, ExpenseDate)
                                values ('" + ex.ExpenseName + "' , '" + ex.ExpenseAmount + "' , '" + ex.ExpenseDate + "' );";

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

        //update - Expenses
        public bool UpdateExpenses(Expenses ex)
        {
            try
            {
                string sql = @"update Expenses set ExpenseName='" + ex.ExpenseName + "' , ExpenseAmount='" + ex.ExpenseAmount + "' , ExpenseDate='" + ex.ExpenseDate + "'  where ExpenseId='" + ex.ExpenseId + "';";

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

        //delete - Expenses
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from Expenses where ExpenseId ='" + id + "';";
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
