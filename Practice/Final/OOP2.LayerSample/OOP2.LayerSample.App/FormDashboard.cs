using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP2.LayerSample.Repository;

namespace OOP2.LayerSample.App
{
    public partial class FormDashboard : Form
    {
        private ProductRepository productRepo {get; set;}
        public FormDashboard()
        {
            InitializeComponent();
            this.productRepo = new ProductRepository();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void PopulateGridView(string searchKey = null)
        {
            //this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.DataSource = this.productRepo.GetAll(searchKey).ToList();
            this.dgvProduct.ClearSelection();
            this.dgvProduct.Refresh();
        }

        //search button
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearch.Text);
        }

        //refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = this.dgvProduct.CurrentRow.Cells["PName"].Value.ToString();

            if (this.dgvProduct.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please Select a Row First to Delete", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var msg = "Are you sure want to delete? " + name.ToUpper();

            DialogResult result = MessageBox.Show(msg, "Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            if (result == DialogResult.OK)
            {
                this.productRepo.Delete(this.dgvProduct.CurrentRow.Cells["Id"].Value.ToString());

                MessageBox.Show(name.ToUpper() + " Data has been deleted", "Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.PopulateGridView();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DelegateCollection.RefreshGrid refresh = this.PopulateGridView;
            new FormAddProduct(productRepo, refresh).Show();
        }
    }
}
