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
    public partial class FormDB : Form
    {
        public FormDB()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection =
                new SqlConnection(
                    @"Data Source=X510UQR\SQLEXPRESS;Initial Catalog=inventoryUserDB;Persist Security Info=True;User ID=sa;Password=madworld");
            sqlConnection.Open(); // Step - 1

            SqlCommand sqlCommand = new SqlCommand("select * from Users;", sqlConnection); // Step - 2

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // Step - 3

            DataSet dataSet = new DataSet(); // Step - 4

            sqlDataAdapter.Fill(dataSet); // Step - 5

            this.lblShow.Text = dataSet.Tables[0].Rows[2][3].ToString();

            sqlConnection.Close(); // Step - 6
        }
    }
}
