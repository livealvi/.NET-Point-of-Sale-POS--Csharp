using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PraticeWindowsFormsApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (this.txtUserId.Text.ToLower().Equals("alvi") && this.txtUserPassword.Text.Equals("123"))
            //{
            //    MessageBox.Show("Login Valid!");
            //}
            //else
            //{
            //    MessageBox.Show("Login Invalid!");
            //    this.ClearContent();
            //}

            string sqlQueryLoginAndPassword = "select * from Users where Id = '" + this.txtUserId.Text + "' and Password = '" + this.txtUserPassword.Text + "';";

            SqlConnection sqlConnection =
                new SqlConnection(
                    @"Data Source=X510UQR\SQLEXPRESS;Initial Catalog=inventoryUserDB;Persist Security Info=True;User ID=sa;Password=madworld");
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(sqlQueryLoginAndPassword, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();

            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count == 1)
            {
                this.Hide();
                MessageBox.Show("Login Valid");

                string name = dataSet.Tables[0].Rows[0][3].ToString();

                if (dataSet.Tables[0].Rows[0][3].ToString() == "admin")
                {
                    FormAdmin admin = new FormAdmin(this, name);
                    admin.Show();
                    ClearContent();
                } else if (dataSet.Tables[0].Rows[0][3].ToString() == "member")
                {
                    FormMember member = new FormMember(this, name);
                    member.Show();
                    ClearContent();
                }

                //FormAdmin admin = new FormAdmin(this);
                //admin.Show();
                ClearContent();
            }
            else
            {
                MessageBox.Show("Login Invalid!");
            }

            //int count = 0;

            //while (count < dataSet.Tables[0].Rows.Count)
            //{
            //    if (this.txtUserId.Text.ToString() == dataSet.Tables[0].Rows[count][0].ToString() && this.txtUserPassword.Text == dataSet.Tables[0].Rows[count][2].ToString())
            //    {
            //        MessageBox.Show("Login Valid!");
            //        break;
            //    }
            //    count++;
            //}
            //sqlConnection.Close();

            //else
            //{
            //    MessageBox.Show("Login Invalid!");
            //}

            sqlConnection.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           this.ClearContent();
        }

        private void ClearContent()
        {
            this.txtUserId.Clear();
            this.txtUserPassword.Clear();
        }
    }
}
