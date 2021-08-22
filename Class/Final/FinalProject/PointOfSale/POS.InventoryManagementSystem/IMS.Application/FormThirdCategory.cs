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
    public partial class FormThirdCategory : Form
    {
        private ThirdCategoriesRepo  thirdCategoriesRepo {get; set;}
        private SecondCategoriesReop secondCategoriesReop{get; set;}
        public FormThirdCategory()
        {
            InitializeComponent();
            this.thirdCategoriesRepo = new ThirdCategoriesRepo();
            this.secondCategoriesReop = new SecondCategoriesReop();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvThirdCate.AutoGenerateColumns = false;
            this.dgvThirdCate.DataSource = this.thirdCategoriesRepo.GetAll(searchKey).ToList();
            this.dgvThirdCate.ClearSelection();
            //this.RefreshContent();
            this.SecondCategoryIdToName();
        }

        private void SecondCategoryIdToName()
        {
            this.cmbSecondCate.Items.Clear();
            this.cmbSecondCate.Items.Add("--Not Selected--");
            this.cmbSecondCate.SelectedIndex = cmbSecondCate.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.secondCategoriesReop.LoadComboMainCategoryName().Rows)
            {
                this.cmbSecondCate.Items.Add(row["SecondCategoryName"].ToString());
            }
        }

        //public void RefreshContent()
        //{
        //    this.txtBrandId.Clear();
        //    this.txtBrandName.Clear();
        //    this.cmbVendor.SelectedIndex = -1;
        //    this.txtBrandDisc.Clear();
        //    this.txtBrandStatus.Clear();
        //    this.txtBrandTag.Clear();
        //}

        private void FormThirdCategory_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void txtSearchCategories_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchCategories.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.txtSearchCategories.Clear();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
