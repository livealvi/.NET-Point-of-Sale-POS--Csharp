using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess;
using IMS.Entity;

namespace IMS.Repository
{
    public class UsersRepo
    {
        private InventoryDBDataAccess iDB{ get; set; }

        public UsersRepo()
        {
            this.iDB = new InventoryDBDataAccess();
        }

        public List<Users> GetAll(string key)
        {
            List<Users> usersList = new List<Users>();
            string sql;

            try
            {
                if (key == null)  //
                    sql = @"SELECT UserId, UserTag, FirstName,  LastName, Age, Gender, Role, Salary, JoinDate, Birthdate,   NID, Phone,
                          HomeTown, CurrentCity, Division, BloodGroup, PostalCode
                          FROM Users";

                else //   
                    sql = @"SELECT UserId, UserTag, FirstName, LastName, Age, Gender, Role, Salary, JoinDate, Birthdate, NID, Phone,
                          HomeTown, CurrentCity, Division, BloodGroup, PostalCode
                          FROM Users
                          where UserId like '%" + key + "%' or UserTag like '%" + key + "%' or FirstName like '%" + key + "%' or LastName like '%" + key + "%' " +
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
            users.UserId = Convert.ToInt32(row["UserId"].ToString());
            users.UserTag = row["UserTag"].ToString();
            users.FirstName = row["FirstName"].ToString();
            users.LastName = row["LastName"].ToString();
            users.Age = Convert.ToInt32(row["UserId"].ToString());
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

        //Load Combo for users
        public DataTable LoadComboUsersName()
        {
            string sql;
            try
            {
                sql = @"SELECT UserId , FirstName, LastName, Role FROM Users";
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
                if (users.FirstName == UserFullNameWithRole && users.LastName == UserFullNameWithRole && users.Role == UserFullNameWithRole)
                {
                    return users.UserId;
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
            u.UserId = Convert.ToInt32(row["UserId"].ToString());
            return u;
        }


        //DataCount
        public bool DataExists(int id)
        {
            try
            {
                DataSet ds = iDB.ExecuteQuery("select UserId from Users where UserId=" + id);

                //System.Windows.MessageBox.Show(ds.Tables[0].Rows.Count);
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

        public bool Save(Users uc)
        {
            try //   
            {
                var sql = @"insert into Users (FirstName, LastName, Age, Gender, Role, Salary, JoinDate, Birthdate, NID, Phone,
                                  HomeTown, CurrentCity, Division, BloodGroup, PostalCode)
                                values ('" + uc.FirstName + "', '" + uc.LastName + "', '" + uc.Age + "', '" + uc.Gender + "'," +
                          " '" + uc.Role + "', '" + uc.Salary + "', '" + uc.JoinDate + "', '" + uc.Birthdate + "',   '" + uc.NID + "'," +
                          "'" + uc.Phone + "', '" + uc.HomeTown + "', '" + uc.CurrentCity + "', '" + uc.Division + "', '" + uc.BloodGroup + "'," +
                          "'" + uc.PostalCode + "');";

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

        //update
        public bool UpdateUser(Users uc)
        {
            try
            {
                string sql = @"update Users set FirstName='" + uc.FirstName + "' , LastName='" + uc.LastName + "' ," +
                             "Age='" + uc.Age + "' , Gender='" + uc.Gender + "' ," +
                             "Role='" + uc.Role + "' ,Salary='" + uc.Salary + "' ," +
                             "JoinDate='" + uc.JoinDate + "' ,Birthdate='" + uc.Birthdate + "' ," +
                             "NID='" + uc.NID + "' ,Phone='" + uc.Phone + "' ," +
                             "HomeTown='" + uc.HomeTown + "' ,CurrentCity='" + uc.CurrentCity + "' ," +
                             "Division='" + uc.Division + "' ,BloodGroup='" + uc.BloodGroup + "' ," +
                             "PostalCode='" + uc.PostalCode + "' where UserId='" + uc.UserId + "' ;";

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

        //delete
        public bool Delete(string id)
        {
            string sql;

            try
            {
                sql = @"delete from Users where UserId ='" + id + "';";
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
