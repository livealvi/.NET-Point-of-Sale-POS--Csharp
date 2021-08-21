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
            this.AutoIdGenerate();
        }

        private void PopulateGridView(string sql = "select * from Movies;")
        {
            var ds = this.Da.ExecuteQuery(sql);
            this.dgvMovie.AutoGenerateColumns = false;
            this.dgvMovie.DataSource = ds.Tables[0];
        }

        //Show All Data Button
        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        //Search Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from Movies where Genre = '" + this.txtSearch.Text + "';";
                this.PopulateGridView(sql);
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error has occurred: " + exception.Message);
            }
        }

        //Auto Searching
        private void txtAutoSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var sql = "select * from Movies where Title like '" + this.txtAutoSearch.Text + "%' or Id like 'm-" + this.txtMovieId.Text + "%' ;";
                this.PopulateGridView(sql);
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error has occurred: " + exception.Message);

                throw;
            }
        }

        //Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IsValidToSaveData())
                {
                    MessageBox.Show("Invalid to store data, Please fill up all the information");
                    return;
                }

                var query = @"select * from Movies where Id = '" + this.txtMovieId.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    //update
                    var sql = @"update Movies set Title = '" + this.txtMovieTitle.Text + "', IMDB = '" + this.txtMovieIMDB.Text + @"',
                                    Income = '" + this.txtMovieBoxOffice.Text + "', ReleaseDate = '" + this.dtpReleaseDate.Text + @"',
                                    Genre = '" + this.cmbGenre.Text + "' where Id = '" + this.txtMovieId.Text + "';";

                    int count = this.Da.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Data updated successful");
                    }
                    else
                    {
                        MessageBox.Show("Data upgradation failed");
                    }
                }
                else
                {
                    //insert
                    var sql = @"insert into Movies values('" + this.txtMovieId.Text + "','" + this.txtMovieTitle.Text + "'," + this.txtMovieIMDB.Text + "," + this.txtMovieBoxOffice.Text + ",'" + this.dtpReleaseDate.Text + "','" + this.cmbGenre.Text + "');";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Data insertion successful");
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed");
                    }
                }

                this.PopulateGridView();
                this.RefreshContent();
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error has occurred: " + exception.Message);

                throw;
            }
        }

        bool IsValidToSaveData()
        {
            if (String.IsNullOrEmpty(this.txtMovieId.Text) || String.IsNullOrEmpty(this.txtMovieTitle.Text) || String.IsNullOrEmpty(this.txtMovieIMDB.Text) || String.IsNullOrEmpty(this.txtMovieBoxOffice.Text) || String.IsNullOrEmpty(this.dtpReleaseDate.Text) || String.IsNullOrEmpty(this.cmbGenre.Text) || String.IsNullOrWhiteSpace(this.txtMovieId.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Refresh Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.RefreshContent();
        }

        //Delete Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = this.dgvMovie.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvMovie.CurrentRow.Cells[1].Value.ToString();

                var sql = "delete from Movies where Id ='" + id + "';";
                int count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                {
                    MessageBox.Show(name + " Data has been deleted successful");
                }
                else
                {
                    MessageBox.Show("Data deletion failed");
                }
                this.PopulateGridView();
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error has occurred: " + exception.Message);

                throw;
            }
            this.RefreshContent();
        }

        private void dgvMovie_DoubleClick(object sender, EventArgs e)
        {
            this.txtMovieId.Text = this.dgvMovie.CurrentRow.Cells["Id"].Value.ToString();
            this.txtMovieTitle.Text = this.dgvMovie.CurrentRow.Cells["Title"].Value.ToString();
            this.txtMovieIMDB.Text = this.dgvMovie.CurrentRow.Cells["IMDB"].Value.ToString();
            this.txtMovieBoxOffice.Text = this.dgvMovie.CurrentRow.Cells["Income"].Value.ToString();
            this.dtpReleaseDate.Text = this.dgvMovie.CurrentRow.Cells["ReleaseDate"].Value.ToString();
            this.cmbGenre.Text = this.dgvMovie.CurrentRow.Cells["Genre"].Value.ToString();
        }

        private void AutoIdGenerate()
        {
            var sql = "select Id from Movies order by Id desc;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);

            string oldId = dt.Rows[0]["Id"].ToString();
            string[] temp = oldId.Split('-');
            int num = Convert.ToInt32(temp[1]);
            string newId = "m-" + (++num).ToString("d3");

            this.txtMovieId.Text = newId;
        }

        public void RefreshContent()
        {
            this.txtMovieId.Clear();
            this.txtMovieTitle.Clear();
            this.txtMovieIMDB.Clear();
            this.txtMovieBoxOffice.Clear();
            this.dtpReleaseDate.Text = "";
            this.cmbGenre.SelectedIndex = -1;

            this.txtSearch.Clear();
            this.txtAutoSearch.Clear();

            this.AutoIdGenerate();
        }

        private void dgvMovie_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = string.Format("Double Click to Edit Data");
        }
    }
}
