using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPoject
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
            
            this.PopulateGridView();
        }

        private void PopulateGridView(string sql = @"SELECT Products.ProductId AS ProId, ProductName,
                  BrandName, Vendors.VendorName, ProductQuantityPerUnit, ProductPerUnitPrice, ProductMSRP, ProductSize, 
                  ProductColor, ProductWeight, ProductUnitStock, ProductDiscountRate, ProductStatus
                  FROM Products INNER JOIN
                  Brands ON Products.BrandId = Brands.BrandId INNER JOIN
                  Vendors ON Brands.VendorId = Vendors.VendorId;")
        {
            
            this.dgvAddProduct.AutoGenerateColumns = false;

        }

        

        private void dgvProductAllCate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            
        }




        //public void RefreshContent()
        //{
        //    this.txtName.Clear();
        //    this.cmbBrand.Clear();
        //    this.txtMovieIMDB.Clear();
        //    this.txtMovieBoxOffice.Clear();
        //    this.dtpReleaseDate.Text = "";
        //    this.cmbGenre.SelectedIndex = -1;

        //    this.txtSearch.Clear();
        //    this.txtAutoSearch.Clear();

        //    this.AutoIdGenerate();
        //}
    }
}
