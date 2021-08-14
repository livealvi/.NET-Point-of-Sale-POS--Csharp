using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP2.LayerSample.Entity;
using OOP2.LayerSample.Framework;
using OOP2.LayerSample.Repository;

namespace OOP2.LayerSample.App
{
    public partial class FormAddProduct : Form
    {
        private ProductRepository productRepo{get; set;}
        private DelegateCollection.RefreshGrid refreshGrid{get; set;}
        public FormAddProduct()
        {
            InitializeComponent();
        }

        public FormAddProduct(ProductRepository pr, DelegateCollection.RefreshGrid refresh) : this()
        {
            this.productRepo = pr;
            this.refreshGrid = refresh;
        }

        private void btnConfirmAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var productObject = this.FillEntity();

                if (productObject == null)
                {
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var decision = this.productRepo.Save(productObject);

                if (decision)
                {
                    MessageBox.Show("Data Insert Complete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.refreshGrid();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show("Error in data insert", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            this.Hide();
        }

        private bool IsValidToSave()
        {
            if (Validation.IsStringInvalid(this.txtAppId.Text) || Validation.IsStringInvalid(this.txtName.Text) ||
                Validation.IsIntValid(this.txtQuantity.Text) || Validation.IsFloatValid(this.txtUnitPrice.Text))

                return true;

            return false;
        }

        private Product FillEntity()
        {
            if (!this.IsValidToSave())
                return null;

            var p = new Product();
            p.AppId = this.txtAppId.Text;
            p.PName = this.txtName.Text;
            p.Quantity = Convert.ToInt32(this.txtQuantity.Text);
            p.UnitPrice = Convert.ToInt32(this.txtUnitPrice.Text);

            return p;
        }
    }
}
