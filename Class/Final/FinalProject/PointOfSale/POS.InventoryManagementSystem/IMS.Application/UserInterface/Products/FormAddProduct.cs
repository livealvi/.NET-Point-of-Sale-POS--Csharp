using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using IMS.Entity;
using IMS.Entity.InventoryProducts;
using IMS.Repository;
using IMS.Framework;


namespace FinalPoject
{
    public partial class FormAddProduct : Form
    {
        private ProductsRepo                    productRepo{get;  set;}
        private BrandsRepo                     brandRepo  {get;  set;}
        public FormAddProduct()
        {
            InitializeComponent();
            this.productRepo = new ProductsRepo();
            this.brandRepo = new BrandsRepo();
            this.RefreshContent();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvAllProduct.AutoGenerateColumns = false;
            this.dgvAllProduct.DataSource = this.productRepo.GetAll(searchKey).ToList();
            this.dgvAllProduct.ClearSelection();
            this.Refresh();
            this.RefreshContent();
            this.BrandIdToName();
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


        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchProduct.Text);
        }


        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            
            try
            {
                Products proObj = this.FillEntity();
                if (proObj == null)
                {
                    proObj = new Products();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                var decision = this.productRepo.DataExists(proObj.ProductId);

                if (decision)
                {
                    //Update
                    if (this.productRepo.UpdateProduct(proObj))
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
                    if (this.productRepo.Save(proObj))
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

        private bool IsValidToSave()
        {

            if (Validation.IsStringInvalid(this.txtName.Text) ) 

                return true;

            return false;
        }

        //|| Validation.IsStringInvalid(this.txtDiscription.Text) || 
        //Validation.IsFloatValid(this.txtQuantityPerUnit.Text) || Validation.IsFloatValid(this.txtPerUnitPrice.Text) ||
        //Validation.IsFloatValid(this.txtMSRP.Text) || Validation.IsStringInvalid(this.txtStatus.Text) ||
        //Validation.IsFloatValid(this.txtDiscountRate.Text) || Validation.IsFloatValid(this.txtSize.Text) ||
        //Validation.IsStringInvalid(this.txtColor.Text) || Validation.IsFloatValid(this.txtWeight.Text) ||
        //Validation.IsStringInvalid(this.txtUniStock.Text)


        private Products FillEntity()
        {
            //if (!this.IsValidToSave())
            //{
            //    return null;
            //}

             var product = new Products();

            if (this.txtId.Text == "")
            {
                product.ProductId = 0;
            }
            else
            {
                product.ProductId = Convert.ToInt32(this.txtId.Text);
            }

            product.ProductName = this.txtName.Text;
            product.ProductStatus = this.txtStatus.Text;
            product.ProductMSRP = Convert.ToDouble(this.txtMSRP.Text);
            product.BrandId = brandRepo.GetBrandId(this.cmbBrand.Text);
            product.ProductPerUnitPrice = Convert.ToDouble(this.txtPerUnitPrice.Text);
            product.ProductQuantityPerUnit = Convert.ToDouble(this.txtQuantityPerUnit.Text);
            product.ProductDiscountRate = Convert.ToDouble(this.txtDiscountRate.Text);
            product.ProductSize = Convert.ToDouble(this.txtSize.Text);
            product.ProductColor = this.txtColor.Text;
            //proCateMas.ProductPictures = new[] { Convert.ToByte(row["pPictures"].ToString()) };
            product.ProductWeight = Convert.ToDouble(this.txtWeight.Text);
            product.ProductUnitStock = Convert.ToInt32(this.txtUniStock.Text);
            product.ProductDescription = this.txtDiscription.Text;

            return product;
        }


        private void dgvAllProduct_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = this.dgvAllProduct.CurrentRow.Cells["pID"].Value.ToString();
            this.txtTag.Text = this.dgvAllProduct.CurrentRow.Cells["pTag"].Value.ToString();
            this.txtName.Text = this.dgvAllProduct.CurrentRow.Cells["pName"].Value.ToString();
            this.cmbBrand.Text = dgvAllProduct.CurrentRow.Cells["pBrandName"].Value.ToString();
            this.txtQuantityPerUnit.Text = this.dgvAllProduct.CurrentRow.Cells["pQuaPerUn"].Value.ToString();
            this.txtPerUnitPrice.Text = this.dgvAllProduct.CurrentRow.Cells["pPerUnPrice"].Value.ToString();
            this.txtMSRP.Text = this.dgvAllProduct.CurrentRow.Cells["pMSRP"].Value.ToString();
            this.txtSize.Text = this.dgvAllProduct.CurrentRow.Cells["pSize"].Value.ToString();
            this.txtColor.Text = this.dgvAllProduct.CurrentRow.Cells["pColor"].Value.ToString();
            this.txtWeight.Text = this.dgvAllProduct.CurrentRow.Cells["pWeight"].Value.ToString();
            this.txtUniStock.Text = this.dgvAllProduct.CurrentRow.Cells["pUnStock"].Value.ToString();
            this.txtDiscountRate.Text = this.dgvAllProduct.CurrentRow.Cells["pDisRate"].Value.ToString();
            this.txtStatus.Text = this.dgvAllProduct.CurrentRow.Cells["pStatus"].Value.ToString();
            this.txtDiscription.Text = this.dgvAllProduct.CurrentRow.Cells["pDisc"].Value.ToString();
        }


        public void RefreshContent()
        {
            this.txtId.Clear();
            this.txtTag.Clear();
            this.txtName.Clear();
            this.cmbBrand.SelectedIndex = -1;
            this.txtQuantityPerUnit.Clear();
            this.txtPerUnitPrice.Clear();
            this.txtMSRP.Clear();
            this.txtSize.Clear();
            this.txtColor.Clear();
            this.txtWeight.Clear();
            this.txtUniStock.Clear();
            this.txtDiscountRate.Clear();
            this.txtStatus.Clear();
            this.txtDiscription.Clear();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            var id = this.dgvAllProduct.CurrentRow.Cells["pID"].Value.ToString();
            var name = this.dgvAllProduct.CurrentRow.Cells["pName"].Value.ToString();

            if (this.productRepo.Delete(id))
            {
                MessageBox.Show(name + " - Delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Error Del");
            }
            this.PopulateGridView();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.txtSearchProduct.Clear();
            PopulateGridView();
        }

        private void btnAddBarnd_Click(object sender, EventArgs e)
        {
            FormBrand brand = new FormBrand();
            brand.ShowDialog();
        }
    }
}
