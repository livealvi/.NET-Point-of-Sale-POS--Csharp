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
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormMakeSale : Form
    {
        private DataTable OrderDetailDataTable;
        private int counter = 0;
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
            //this.MainCategoryIdToName();
            //this.ItemFound();
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
            this.txtProductQuant.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductUnitStock"].Value.ToString();
            this.txtProductPerUnitPrice.Text= this.dgvSearchProduct.CurrentRow.Cells["ProductPerUnitPrice"].Value.ToString();
            this.txtDiscount.Text = this.dgvSearchProduct.CurrentRow.Cells["ProductDiscountRate"].Value.ToString();
            this.txtProductMSRP.Text= this.dgvSearchProduct.CurrentRow.Cells["ProductMSRP"].Value.ToString();
            this.txtBrand.Text = this.dgvSearchProduct.CurrentRow.Cells["BrandName"].Value.ToString();

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            DataRow row = OrderDetailDataTable.NewRow();
            foreach (DataColumn col in OrderDetailDataTable.Columns)
            {
                row[col.ColumnName] = dgvSearchProduct.SelectedRows[0].Cells[counter++].Value.ToString();
            }

            row["ProductId"] = dgvSearchProduct.SelectedRows[0].Cells[0].Value.ToString();
            row["ProductIdTag"] = dgvSearchProduct.SelectedRows[0].Cells[1].Value.ToString();
            row["ProductName"] = dgvSearchProduct.SelectedRows[0].Cells[2].Value.ToString();
            row["ProductUnitStock"] = dgvSearchProduct.SelectedRows[0].Cells[3].Value.ToString();
            row["ProductPerUnitPrice"] = dgvSearchProduct.SelectedRows[0].Cells[4].Value.ToString();
            row["ProductDiscountRate"] = dgvSearchProduct.SelectedRows[0].Cells[5].Value.ToString();
            row["ProductMSRP"] = dgvSearchProduct.SelectedRows[0].Cells[6].Value.ToString();
            row["BrandName"] = dgvSearchProduct.SelectedRows[0].Cells[7].Value.ToString();

            OrderDetailDataTable.Rows.Add(row);
            counter = 0;

            //this.dgvSelect.CurrentRow.Cells["ProductName"].Value = this.dgvSearchProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            //this.dgvSelect.CurrentRow.Cells["ProId"].Value = this.txtProductId.Text;
            //this.dgvSelect.CurrentRow.Cells["ProductIdTag"].Value = this.dgvSearchProduct.CurrentRow.Cells["ProductIdTag"].Value.ToString();
            //this.dgvSelect.CurrentRow.Cells["ProductUnitStock"].Value = this.dgvSearchProduct.CurrentRow.Cells["ProductUnitStock"].Value.ToString();
            //this.dgvSelect.CurrentRow.Cells["ProductPerUnitPrice"].Value = this.dgvSearchProduct.CurrentRow.Cells["ProductPerUnitPrice"].Value.ToString();
            //this.dgvSelect.CurrentRow.Cells["ProductDiscountRate"].Value = this.dgvSearchProduct.CurrentRow.Cells["ProductDiscountRate"].Value.ToString();
            //this.dgvSelect.CurrentRow.Cells["ProductMSRP"].Value = this.dgvSearchProduct.CurrentRow.Cells["ProductMSRP"].Value.ToString();
            //this.dgvSelect.CurrentRow.Cells["BrandName"].Value = this.dgvSearchProduct.CurrentRow.Cells["BrandName"].Value.ToString();

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
            //this.dgvSearchProduct.SelectedRows[0].Cells[0] ;
        }
    }
}
