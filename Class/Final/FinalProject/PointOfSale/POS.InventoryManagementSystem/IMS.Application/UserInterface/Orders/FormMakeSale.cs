using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormMakeSale : Form
    {
        private MasterCategoriesRepo masterCategoriesRepo{ get; set; }
        private ThirdCategoriesRepo  thirdCategoriesRepo { get; set; }
        private SecondCategoriesReop secondCateReop      { get; set; }
        private VendorsRepo          vendorsRepo         { get; set; }
        private BrandsRepo           brandRepo           { get; set; }
        private UsersRepo            usersRepo           { get; set; }
        private DataTable OrderDetailDataTable;
        private OrdersRepo makeSalesRepo{get; set;}
        public FormMakeSale()
        {
            InitializeComponent();
            
            this.makeSalesRepo = new OrdersRepo();
            this.secondCateReop = new SecondCategoriesReop();
            this.thirdCategoriesRepo = new ThirdCategoriesRepo();
            this.vendorsRepo = new VendorsRepo();
            this.brandRepo = new BrandsRepo();
            this.usersRepo = new UsersRepo();
            InitiateDgvcart();
        }


        private void UsersIdToName()
        {
            this.cmbPayByUser.Items.Clear();
            this.cmbPayByUser.Items.Add("--Not Selected--");
            this.cmbPayByUser.SelectedIndex = cmbPayByUser.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.usersRepo.LoadComboUsersName().Rows)
            {
                this.cmbPayByUser.Items.Add(row["FirstName"].ToString() + " " + row["LastName"].ToString() +" - "+ row["Role"].ToString()) ;
            }
        }

        void InitiateDgvcart()
        {
            OrderDetailDataTable = new DataTable();
            OrderDetailDataTable.Clear();

            dgvCart.AutoGenerateColumns = false;
            
            foreach (DataGridViewTextBoxColumn col in dgvSearchProduct.Columns)
            {
                OrderDetailDataTable.Columns.Add(col.HeaderText);
            }

            dgvCart.DataSource = OrderDetailDataTable;
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvSearchProduct.AutoGenerateColumns = false;
            this.dgvSearchProduct.DataSource = this.makeSalesRepo.GetAll(searchKey);
            this.dgvSearchProduct.ClearSelection();
            this.SecondCategoryIdToName();
            this.ThirdCategoryIdToName();
            this.BrandIdToName();
            this.VendorIdToName();
            this.UsersIdToName();
            this.Refresh();
            this.RefreshContent();
        }

        private void FormMakeSale_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void dgvSearchProdcut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtProductName.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            this.txtProductId.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductId"].Value.ToString();
            this.txtProducTag.Text= this.dgvSearchProduct.CurrentRow.Cells["ProductIdTag"].Value.ToString();
            this.txtPorductItemLeft.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductUnitStock"].Value.ToString();
            this.txtProductPerUnitPrice.Text= this.dgvSearchProduct.CurrentRow.Cells["ProductPerUnitPrice"].Value.ToString();
            this.txtDiscount.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductDiscountRate"].Value.ToString();
            this.txtProductMSRP.Text= this.dgvSearchProduct.CurrentRow.Cells["ProductMSRP"].Value.ToString();
            this.txtBrand.Text = this.dgvSearchProduct.CurrentRow.Cells["BrandName"].Value.ToString();

        }

        void UpdatePrice()
        {
            double price = 0.0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                price += double.Parse(row.Cells[6].Value.ToString());
            }

            txtTotalAmount.Text = price.ToString();

            txtNewVatAmount.Text = (price * 1.15).ToString();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            DataRow row = OrderDetailDataTable.NewRow();

            row["ProductId"] = dgvSearchProduct.SelectedRows[0].Cells[0].Value.ToString();
            row["ProductIdTag"] = dgvSearchProduct.SelectedRows[0].Cells[1].Value.ToString();
            row["ProductName"] = dgvSearchProduct.SelectedRows[0].Cells[2].Value.ToString();
            row["ProductUnitStock"] = dgvSearchProduct.SelectedRows[0].Cells[3].Value.ToString();
            row["ProductPerUnitPrice"] = dgvSearchProduct.SelectedRows[0].Cells[4].Value.ToString();
            row["ProductDiscountRate"] = dgvSearchProduct.SelectedRows[0].Cells[5].Value.ToString();
            row["ProductMSRP"] = dgvSearchProduct.SelectedRows[0].Cells[6].Value.ToString();
            row["BrandName"] = dgvSearchProduct.SelectedRows[0].Cells[7].Value.ToString();

            OrderDetailDataTable.Rows.Add(row);

            UpdatePrice();

        }

        private void txtSearchForSell_TextChanged_1(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchForSell.Text);
        }

        private void RefreshContent()
        {
            this.txtProductName.Clear();
            this.txtProductId.Clear();
            this.txtProducTag.Clear();
            this.txtProductQuant.Clear();
            this.txtProductPerUnitPrice.Clear();
            this.txtDiscount.Clear();
            this.txtProductMSRP.Clear();
            this.txtBrand.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
            this.RefreshContent();
            this.txtSearchForSell.Clear();
        }

        private void btnCancleSearch_Click(object sender, EventArgs e)
        {
            this.txtSearchForSell.Clear();
            this.PopulateGridView();
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
            this.cmbThird.Items.Clear();
            this.cmbThird.Items.Add("--Not Selected--");
            this.cmbThird.SelectedIndex = cmbThird.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.thirdCategoriesRepo.LoadComboThirdCategoryName().Rows)
            {
                this.cmbThird.Items.Add(row["ThirdCategoryName"].ToString());
            }
        }
        private void SecondCategoryIdToName()
        {
            this.cmbSecond.Items.Clear();
            this.cmbSecond.Items.Add("--Not Selected--");
            this.cmbSecond.SelectedIndex = cmbSecond.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.secondCateReop.LoadComboMainCategoryName().Rows)
            {
                this.cmbSecond.Items.Add(row["SecondCategoryName"].ToString());
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                this.dgvCart.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
            }
            else
            {
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("No Item to remove ");
                }
                else
                {
                    MessageBox.Show("Select a Item to remove");
                }
                

            }

        }

        private Orders FillEntity()
        {

            var orders = new Orders();
           
           orders.ProductName = this.txtProductName.Text;
           orders.ProductPerUnitPrice = Convert.ToDouble(this.txtProductPerUnitPrice.Text);
           orders.CustomerFullName = this.txtCoustomerName.Text;
           orders.CustomerAddress = this.txtCustomerAddress.Text;
           orders.CustomerPhone = this.txtCustomerPhone.Text;
           orders.OrderQuantity = Convert.ToInt32(this.txtProductQuant.Text);
           orders.Date = Convert.ToDateTime(Convert.ToDateTime(dtpPayDate.Value).ToString("yyyy-MM-dd"));
           orders.TotalAmount = Convert.ToDouble(this.txtTotalAmount.Text);
           orders.OrderStatus = this.cmbPayStatus.Text;
           orders.PaymentMethod = this.cmbPaymentMethod.Text;
           orders.UserId = usersRepo.GetUsersdId(this.cmbPayByUser.Text);

            return orders;
        }

        private void btnPlaceOrderToSave_Click(object sender, EventArgs e)
        {
            try
            {
                Orders orObj = this.FillEntity();
                if (orObj == null)
                {
                    orObj = new Orders();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (this.makeSalesRepo.SaveOrders(orObj))
                    {
                        MessageBox.Show("Save Successfully");
                        dgvCart.Rows.Clear();
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

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
