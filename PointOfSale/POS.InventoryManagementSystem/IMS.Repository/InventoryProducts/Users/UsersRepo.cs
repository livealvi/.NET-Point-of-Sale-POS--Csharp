using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity.InventoryProducts;

namespace IMS.Repository
{
    public class UsersRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public UsersRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        public string GetAdminSal()
        {
            return iDB.GetSingleData("select sum(Salary) as id from users where Role='Admin' ", "Id");
        }
        public string GetSalesmanSal()
        {
            return iDB.GetSingleData("select sum(Salary) as id from users where Role='Salesman' ", "Id");
        }
        public string GetCashierSal()
        {
            return iDB.GetSingleData("select sum(Salary) as id from users where Role='Cashier' ", "Id");
        }
        public string GetTotalSal()
        {
            return iDB.GetSingleData("  select sum(Salary) as id from users ", "Id");
        }

        //
        public string GetTotalAdmin()
        {
            return iDB.GetSingleData("select count(Id) as Id from users where Role='Admin' ", "Id");
        }
        public string GetTotalSalesman()
        {
            return iDB.GetSingleData("select count(Id) as Id from users where Role='Salesman' ", "Id");
        }
        public string GetTotalCashier()
        {
            return iDB.GetSingleData("select count(Id) as Id from users where Role='Cashier' ", "Id");
        }
        public string GetTotalUser()
        {
            return iDB.GetSingleData("select count(Id) as Id from users", "Id");
        }

        //Login
        public string GetRole(string username, string password)
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;
            string columnData = null;
            try
            {
                connection = iDB.Sqlcon;
                SqlCommand cmd = new SqlCommand("select Role as role from Users where UserId='" + username + "' and Password='" + password + "'", connection);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    columnData = reader["role"].ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                connection?.Close();
                reader?.Close();
            }
            return columnData;
        }


        //view & search
        public List<Users> GetAll(string key)
        {
            List<Users> usersList = new List<Users>();
            string sql;
            try
            {
                if (key == null)
                    sql = @"SELECT Id, UserId, FirstName, LastName, Password, Email, Age, Gender, Role, Salary, JoinDate, Birthdate,   NID, Phone,
                          HomeTown, CurrentCity, Division, BloodGroup, PostalCode
                          FROM Users";

                else 
                    sql = @"SELECT Id, UserId, FirstName, LastName, Password, Email, Age, Gender, Role, Salary, JoinDate, Birthdate, NID, Phone,
                          HomeTown, CurrentCity, Division, BloodGroup, PostalCode
                          FROM Users
                          where UserId like '%" + key + "%' or Email like '%" + key + "%' or FirstName like '%" + key + "%' or LastName like '%" + key + "%' " +
                          " or Age like '%" + key + "%' or Gender like '%" + key + "%' or Role like '%" + key + "%' " +
                          "or Salary like '%" + key + "%' or JoinDate like '%" + key + "%' or Birthdate like '%" + key + "%' " +
                          "or NID like '%" + key + "%' or Phone like '%" + key + "%'" +
                          "or HomeTown like '%" + key + "%' or CurrentCity like '%" + key + "%' or Division like '%" + key + "%'" +
                          "or BloodGroup like '%" + key + "%' or PostalCode like '%" + key + "%' ; ";

                var dt = this.iDB.ExecuteQueryTable(sql);

                int x = 0;
                while (x < dt.Rows.Count)
                {
                    Users u = this.ConvertToEntity(dt.Rows[x]);
                    usersList.Add(u);
                    x++;
                }
                return usersList;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private Users ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var users = new Users();
            users.Id = Convert.ToInt32(row["Id"].ToString());
            users.UserId = row["UserId"].ToString();
            users.FirstName = row["FirstName"].ToString();
            users.LastName = row["LastName"].ToString();
            users.Password = row["Password"].ToString();
            users.Email = row["Email"].ToString();
            users.Age = Convert.ToInt32(row["Age"].ToString());
            users.Gender = row["Gender"].ToString();
            users.Role = row["Role"].ToString();
            users.Salary = Convert.ToDouble(row["Salary"].ToString());
            users.JoinDate = Convert.ToDateTime(row["JoinDate"].ToString());
            users.Birthdate = Convert.ToDateTime(row["BirthDate"].ToString());
            users.NID = row["NID"].ToString();
            users.Phone = row["Phone"].ToString();
            users.HomeTown = row["HomeTown"].ToString();
            users.CurrentCity = row["CurrentCity"].ToString();
            users.Division = row["Division"].ToString();
            users.BloodGroup = row["BloodGroup"].ToString();
            users.PostalCode = Convert.ToInt32(row["PostalCode"].ToString());
            return users;
        }

        //Load ComboBox
        public DataTable LoadComboUsersName()
        {
            string sql;
            try
            {
                sql = @"SELECT Id , FirstName, LastName, Role FROM Users";
                return this.iDB.ExecuteQueryTable(sql);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Users> GetUsersList()
        {
            DataTable dt = LoadComboUsersName();

            List<Users> list = new List<Users>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(ConvertToUsersList(row));
            }

            return list;
        }

        public int GetUsersdId(string UserFullNameWithRole)
        {
            List<Users> list = GetUsersList();

            foreach (Users users in list)
            {
                //if (users.FirstName == UserFullNameWithRole && users.LastName == UserFullNameWithRole && users.Role == UserFullNameWithRole)
                //{
                //    return users.Id;
                //}

                if (UserFullNameWithRole == users.FirstName + " " + users.LastName + " - " + users.Role)
                {
                    return users.Id;
                }
            }
            return 0;
        }

        private Users ConvertToUsersList(DataRow row)
        {
            if (row == null)
            {
                return null;
            }

            var u = new Users();
            u.FirstName = row["FirstName"].ToString();
            u.LastName = row["LastName"].ToString();
            u.Role = row["Role"].ToString();
            u.Id = Convert.ToInt32(row["Id"].ToString());
            return u;
        }

        //DataCount - DataExists
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select Id from Users where Id=" + id);

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

        //save - user
        public bool Save(Users uc)
        {
            try
            {
                var sql = @"insert into Users (FirstName, LastName,  Password, Email, Age, Gender, Role, Salary, JoinDate, Birthdate, NID, Phone,
                                 HomeTown, CurrentCity, Division, BloodGroup, PostalCode)
                                 values ('" + uc.FirstName + "', '" + uc.LastName + "', '" + uc.Password + "', '" + uc.Email + "',  '" + uc.Age + "', '" + uc.Gender + "'," +
                                 " '" + uc.Role + "', '" + uc.Salary + "', '" + uc.JoinDate + "', '" + uc.Birthdate + "',   '" + uc.NID + "'," +
                                 " '" + uc.Phone + "', '" + uc.HomeTown + "', '" + uc.CurrentCity + "', '" + uc.Division + "', '" + uc.BloodGroup + "'," +
                                 " '" + uc.PostalCode + "');";

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

        //update - user
        public bool UpdateUser(Users uc)
        {
            try
            {
                string sql = @" update Users set FirstName='" + uc.FirstName + "' , LastName='" + uc.LastName + "' ," +
                             " Password='" + uc.Password + "' , Email='" + uc.Email + "' , Age='" + uc.Age + "' , Gender='" + uc.Gender + "' ," +
                             " Role='" + uc.Role + "' ,Salary='" + uc.Salary + "' ," +
                             " JoinDate='" + uc.JoinDate + "' ,Birthdate='" + uc.Birthdate + "' ," +
                             " NID='" + uc.NID + "' ,Phone='" + uc.Phone + "' ," +
                             " HomeTown='" + uc.HomeTown + "' ,CurrentCity='" + uc.CurrentCity + "' ," +
                             " Division='" + uc.Division + "' ,BloodGroup='" + uc.BloodGroup + "' ," +
                             " PostalCode='" + uc.PostalCode + "' where Id='" + uc.Id + "' ;";

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

        //delete - user
        public bool Delete(string id)
        {
            string sql;
            try
            {
                sql = @"delete from Users where Id ='" + id + "';";
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
