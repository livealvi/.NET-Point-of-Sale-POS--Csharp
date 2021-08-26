using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Entity;
using IMS.Entity.InventoryProducts;
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
            this.cmbStatus.StartIndex= 0;
            this.txtVendorTag.Clear();
            this.dtpRegisterDate.Text = "";
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

        private void btnDeleteVendor_Click(object sender, EventArgs e)
        {
            var id = this.dgvVendor.CurrentRow.Cells["VendorId"].Value.ToString();
            var name = this.dgvVendor.CurrentRow.Cells["VendorName"].Value.ToString();

            if (this.vendorsRepo.Delete(id))
            {
                MessageBox.Show(name + " - Delete Succeeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Error Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.PopulateGridView();
        }

        private void dgvVendor_DoubleClick(object sender, EventArgs e)
        {
            this.txtVendorId.Text = this.dgvVendor.CurrentRow.Cells["VendorId"].Value.ToString();
            this.txtVendorName.Text = this.dgvVendor.CurrentRow.Cells["VendorName"].Value.ToString();
            this.txtVendorTag.Text = this.dgvVendor.CurrentRow.Cells["VendorTag"].Value.ToString();
            this.cmbThirdCate.Text = this.dgvVendor.CurrentRow.Cells["ThirdCategoryName"].Value.ToString();
            this.txtVendorDisc.Text = this.dgvVendor.CurrentRow.Cells["VendorDisc"].Value.ToString();
            this.dtpRegisterDate.Text = this.dgvVendor.CurrentRow.Cells["RegisterDate"].Value.ToString();
            this.cmbStatus.Text = this.dgvVendor.CurrentRow.Cells["VendorStatus"].Value.ToString();
        }

        private void btnSaveVendor_Click(object sender, EventArgs e)
        {
            try
            {
                Vendors vrObj = this.FillEntity();
                if (vrObj == null)
                {
                    vrObj = new Vendors();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var decision = this.vendorsRepo.DataExists(vrObj.VendorId);

                if (decision)
                {
                    //Update
                    if (this.vendorsRepo.UpdateProduct(vrObj))
                    {
                        MessageBox.Show("Update Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    //Save
                    if (this.vendorsRepo.Save(vrObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                this.PopulateGridView();
            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Vendors FillEntity()
        {
            //if (!this.IsValidToSave())
            //{
            //    return null;
            //}

            var vendor = new Vendors();

            if (this.txtVendorId.Text == "")
            {
                vendor.VendorId = 0;
            }
            else
            {
                vendor.VendorId = Convert.ToInt32(this.txtVendorId.Text);
            }

            vendor.VendorName = this.txtVendorName.Text;
            vendor.VendorDescription = this.txtVendorDisc.Text;
            vendor.ThirdCategoryId = thirdCategoriesRepo.GetThirdCateId(this.cmbThirdCate.Text);
            vendor.RegisterDate = Convert.ToDateTime(Convert.ToDateTime(dtpRegisterDate.Value).ToString("yyyy-MM-dd"));
            vendor.VendorStatus = cmbStatus.Text;
            vendor.VendorDescription = txtVendorDisc.Text;
            return vendor;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddThirdCate_Click(object sender, EventArgs e)
        {
            FormThirdCategory thirdCategory = new FormThirdCategory();
            thirdCategory.ShowDialog();
        }
    }
}
