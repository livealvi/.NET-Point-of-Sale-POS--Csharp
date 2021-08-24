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
using IMS.Entity;
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormMakeSale : Form
    {
        private DataTable OrderDetailDataTable;
        private MakeSalesRepo makeSalesRepo{get; set;}
        public FormMakeSale()
        {
            InitializeComponent();
            this.makeSalesRepo = new MakeSalesRepo();

            InitiateDgvcart();
        }

        void InitiateDgvcart()
        {
            OrderDetailDataTable = new DataTable();
            OrderDetailDataTable.Clear();

            dgvCart.AutoGenerateColumns = false;
            //OrderDetailDataTable.Columns.Add("ProductName");
            //OrderDetailDataTable.Columns.Add("ProductName");
            //OrderDetailDataTable.Columns.Add("ProductName");
            //OrderDetailDataTable.Columns.Add("ProductName");
            //OrderDetailDataTable.Columns.Add("ProductName");

            //foreach (string col in new[] {"ProductName","ProductId"})
            //{
            //}

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
                    if (this.makeSalesRepo.SaveOrders())
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
