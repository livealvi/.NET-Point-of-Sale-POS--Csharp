using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormProductsMaster : Form
    {
        private MasterCategoriesRepo masterCategoriesRepo{get;  set;}
        private MainCategoriesRepo   mainCategoriesRepo  {get;  set;}
        private ThirdCategoriesRepo  thirdCategoriesRepo { get; set; }
        private SecondCategoriesReop secondCateReop      { get; set; }
        private VendorsRepo          vendorsRepo         { get; set; }
        private BrandsRepo           brandRepo           { get; set; }
        public FormProductsMaster() 
        {
            InitializeComponent();
            this.masterCategoriesRepo = new MasterCategoriesRepo();
            this.mainCategoriesRepo = new MainCategoriesRepo();
            this.secondCateReop = new SecondCategoriesReop();
            this.thirdCategoriesRepo = new ThirdCategoriesRepo();
            this.vendorsRepo = new VendorsRepo();
            this.brandRepo = new BrandsRepo();

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
            this.RefreshContent();
            this.txtSerachAllCate.Clear();
        }


        private void PopulateGridView(string searchKey = null)
        {
            this.dgvMasterView.AutoGenerateColumns = false;
            this.dgvMasterView.DataSource = this.masterCategoriesRepo.GetAll(searchKey).ToList();
            this.dgvMasterView.ClearSelection();
            this.Refresh();
            this.RefreshContent();
            this.MainCategoryIdToName();
            this.SecondCategoryIdToName();
            this.ThirdCategoryIdToName();
            this.BrandIdToName();
            this.VendorIdToName();
        }

        private void BrandIdToName()
        {
            this.cmbBrand.Items.Clear();
            this.cmbBrand.Items.Add("--Not Selected--");
            this.cmbBrand.SelectedIndex = cmbBrand.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.brandRepo.LoadComboBrandName().Rows)
            {
                this.cmbBrand.Items.Add(row["BrandName"].ToString());
            }
        }

        private void VendorIdToName()
        {
            this.cmbVendor.Items.Clear();
            this.cmbVendor.Items.Add("--Not Selected--");
            this.cmbVendor.SelectedIndex = cmbVendor.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.vendorsRepo.LoadComboVendorName().Rows)
            {
                this.cmbVendor.Items.Add(row["VendorName"].ToString());
            }
        }

        private void ThirdCategoryIdToName()
        {
            this.cmbThirdCate.Items.Clear();
            this.cmbThirdCate.Items.Add("--Not Selected--");
            this.cmbThirdCate.SelectedIndex = cmbThirdCate.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.thirdCategoriesRepo.LoadComboThirdCategoryName().Rows)
            {
                this.cmbThirdCate.Items.Add(row["ThirdCategoryName"].ToString());
            }
        }
        private void SecondCategoryIdToName()
        {
            this.cmbSecondCateName.Items.Clear();
            this.cmbSecondCateName.Items.Add("--Not Selected--");
            this.cmbSecondCateName.SelectedIndex = cmbSecondCateName.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.secondCateReop.LoadComboMainCategoryName().Rows)
            {
                this.cmbSecondCateName.Items.Add(row["SecondCategoryName"].ToString());
            }
        }
        private void MainCategoryIdToName()
        {
            this.cmbMainCate.Items.Clear();
            this.cmbMainCate.Items.Add("--Not Selected--");
            this.cmbMainCate.SelectedIndex = cmbMainCate.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.mainCategoriesRepo.LoadComboMainCategoryName().Rows)
            {
                this.cmbMainCate.Items.Add(row["MainCategoryName"].ToString());
            }
        }

        public void RefreshContent()
        {
            this.cmbMainCate.SelectedIndex = -1;
            this.cmbSecondCateName.SelectedIndex = -1;
            this.cmbThirdCate.SelectedIndex = -1;
            this.cmbVendor.SelectedIndex = -1;
            this.cmbBrand.SelectedIndex = -1;
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

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
