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

namespace FinalPoject
{
    public partial class FormBrand : Form
    {
        private BrandsRepo  brandsRepo  { get; set; }
        private VendorsRepo vendorsRepo { get; set; }

        public FormBrand()
        {
            InitializeComponent();
            this.brandsRepo = new BrandsRepo();
            this.vendorsRepo = new VendorsRepo();
            this.RefreshContent();
        }

        
        private void PopulateGridView(string searchKey = null)
        {
            this.dgvBrand.AutoGenerateColumns = false;
            this.dgvBrand.DataSource = this.brandsRepo.GetAll(searchKey).ToList();
            this.dgvBrand.ClearSelection();
            this.RefreshContent();
            this.VendorIdToName();
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

        private void FormBrand_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }


        private void txtSearchBrand_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchBrand.Text);
        }

        public void RefreshContent()
        {
            this.txtBrandId.Clear();
            this.txtBrandName.Clear();
            this.cmbVendor.SelectedIndex = -1;
            this.txtBrandDisc.Clear();
            this.txtBrandStatus.Clear();
            this.txtBrandTag.Clear();
        }

        private void btnBrandRefresh_Click(object sender, EventArgs e)
        {
            this.txtSearchBrand.Clear();
            this.RefreshContent();
        }

        private void dgvBrand_DoubleClick(object sender, EventArgs e)
        {
            this.txtBrandId.Text = this.dgvBrand.CurrentRow.Cells["BrandId"].Value.ToString();
            this.txtBrandName.Text = this.dgvBrand.CurrentRow.Cells["BrandName"].Value.ToString();
            this.txtBrandTag.Text = this.dgvBrand.CurrentRow.Cells["BrandTag"].Value.ToString();
            this.cmbVendor.Text = this.dgvBrand.CurrentRow.Cells["VendorName"].Value.ToString();
            this.txtBrandStatus.Text = this.dgvBrand.CurrentRow.Cells["BrandStatus"].Value.ToString();
            this.txtBrandDisc.Text = this.dgvBrand.CurrentRow.Cells["BrandDisc"].Value.ToString();
        }

        private void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            var id = this.dgvBrand.CurrentRow.Cells["BrandId"].Value.ToString();
            var name = this.dgvBrand.CurrentRow.Cells["BrandName"].Value.ToString();

            if (this.brandsRepo.Delete(id))
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

        private void btnSaveBrand_Click(object sender, EventArgs e)
        {
            
                try
                {
                    Brands brObj = this.FillEntity();
                    if (brObj == null)
                    {
                        brObj = new Brands();
                        MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var decision = this.brandsRepo.DataExists(brObj.BrandId);

                    if (decision)
                    {
                        //Update
                        if (this.brandsRepo.UpdateProduct(brObj))
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
                        if (this.brandsRepo.Save(brObj))
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

        private Brands FillEntity()
        {
            //if (!this.IsValidToSave())
            //{
            //    return null;
            //}

            var brand = new Brands();

            if (this.txtBrandId.Text == "")
            {
                brand.BrandId = 0;
            }
            else
            {
                brand.BrandId = Convert.ToInt32(this.txtBrandId.Text);
            }
            
            brand.BrandName = this.txtBrandName.Text;
            brand.BrandDescription = this.txtBrandDisc.Text;
            brand.BrandStatus = this.txtBrandStatus.Text;
            brand.VendorId = vendorsRepo.GetVendorId(this.cmbVendor.Text);
            return brand;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddVendors_Click(object sender, EventArgs e)
        {
            FormVendor vendor = new FormVendor();
            vendor.ShowDialog();
        }
    }
}
