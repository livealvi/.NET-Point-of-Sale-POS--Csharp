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
    public partial class FormProductsMaster : Form
    {
        public FormProductsMaster()
        {
            InitializeComponent();
        }

        
        //
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
