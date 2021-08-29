using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;
using FinalPoject.UserInterface.Dashboard;

namespace FinalPoject
{
    public partial class FormMasterCategory : Form
    {
        private MasterCategoriesRepo masterCategoriesRepo{get;  set;}

        public FormMasterCategory() 
        {
            InitializeComponent();
            this.masterCategoriesRepo = new MasterCategoriesRepo();
        }

        private void FormProductsMaster_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void txtSerachAllCate_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSerachAllCate.Text);
        }

        private void btnMasterRefresh_Click(object sender, EventArgs e)
        {
            this.txtSerachAllCate.Clear();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvMasterView.AutoGenerateColumns = false;
            this.dgvMasterView.DataSource = this.masterCategoriesRepo.GetAll(searchKey).ToList();
            this.dgvMasterView.ClearSelection();
            this.Refresh();
        }

        private void btnAddMainCate_Click(object sender, EventArgs e)
        {
            FormMainCategory mainCategory = new FormMainCategory();
            mainCategory.ShowDialog();
        }

        private void btnAddSecondCate_Click(object sender, EventArgs e)
        {
            FormSecondCategory secondCategory = new FormSecondCategory();
            secondCategory.ShowDialog();
        }

        private void btnAddThirdCate_Click(object sender, EventArgs e)
        {
            FormThirdCategory thirdCategory = new FormThirdCategory();
            thirdCategory.ShowDialog();
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            FormVendor vendor = new FormVendor();
            vendor.ShowDialog();
        }

        private void btnAddBrandCate_Click(object sender, EventArgs e)
        {
            FormBrand brand = new FormBrand();
            brand.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FormAddProduct product = new FormAddProduct();
            product.ShowDialog();
        }

    }
}
