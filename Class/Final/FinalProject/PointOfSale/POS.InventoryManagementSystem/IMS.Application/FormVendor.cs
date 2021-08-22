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
    public partial class FormVendor : Form
    {
        private VendorsRepo         vendorsRepo        {get; set;}
        private ThirdCategoriesRepo thirdCategoriesRepo{get; set;}
        public FormVendor()
        {
            InitializeComponent();
            this.vendorsRepo = new VendorsRepo();
            this.thirdCategoriesRepo = new ThirdCategoriesRepo();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvVendor.AutoGenerateColumns = false;
            this.dgvVendor.DataSource = this.vendorsRepo.GetAll(searchKey).ToList();
            this.dgvVendor.ClearSelection();
            this.RefreshContent();
            this.ThirdCategoryIdToName();
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

        private void FormVendor_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        

        public void RefreshContent()
        {
            this.txtVendorId.Clear();
            this.txtVendorName.Clear();
            this.cmbThirdCate.SelectedIndex = -1;
            this.txtVendorDisc.Clear();
            this.txtVendorStatus.Clear();
            this.txtVendorTag.Clear();
        }

        private void btnVendorRefresh_Click(object sender, EventArgs e)
        {
            this.txtSearchVendor.Clear();
            this.RefreshContent();
        }

        private void txtSearchVendor_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchVendor.Text);
        }
    }
}
