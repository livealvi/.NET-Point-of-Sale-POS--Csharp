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

namespace SQLInnerJoin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = @"SELECT SecondCategoryId, SecondCategoryName, MainCategoryId
            FROM SecondCategories";

            SqlConnection sqlcon = new SqlConnection(@"Data Source=X510UQR\SQLEXPRESS;Initial Catalog=inventoryDB;Persist Security Info=True;User ID=sa;Password=madworld");
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            this.dgvInnerJoin.AutoGenerateColumns = false;
            this.dgvInnerJoin.DataSource = ds.Tables[0];
            
            sqlcon.Close();
        }
    }
}
