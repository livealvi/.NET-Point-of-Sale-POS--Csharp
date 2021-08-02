using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormAppSln
{
    public partial class Dashboard : Form
    {
        private DataAccess Da { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
        }

        private void PopulateGridView(string sql = "select * from Movies;")
        {
            var ds = this.Da.ExecuteQuery(sql);
            this.dgvMovie.AutoGenerateColumns = false;
            this.dgvMovie.DataSource = ds.Tables[0];
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from Movies where Genre = '" + this.txtSearch.Text + "';";
            this.PopulateGridView(sql);
        }

        private void txtAutoSearch_TextChanged(object sender, EventArgs e)
        {
            var sql = "select * from Movies where Title like '" + this.txtAutoSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sql = @"insert into Movies values('" +this.txtMovieId.Text+ "','" + this.txtMovieTitle.Text + "'," + this.txtMovieIMDB.Text + "," + this.txtMovieBoxOffice.Text + ",'" + this.dtReleaseDate.Text + "','" + this.cmbGenre.Text + "');";

            int count = this.Da.ExecuteDMLQuery(sql);

            if (count == 1)
            {
                MessageBox.Show("Data insertion successfull");
            }
            else
            {
                MessageBox.Show("Data insertion failed");
            }

            this.PopulateGridView();
        }
    }
}
