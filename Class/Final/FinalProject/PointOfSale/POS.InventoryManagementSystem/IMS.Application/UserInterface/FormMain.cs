using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalPoject.UserInterface.Dashboard;
using FinalPoject.UserInterface.Exp;
using Guna.UI2.WinForms;

namespace FinalPoject
{
    public partial class FormStart : Form
    {
        private string role;
        private Form loginForm;
        public FormStart(string role, Form form)
        {
            InitializeComponent();

            this.loginForm = form;
            this.role = role;

            if (role == "Admin")
            {
                SetupForAdmin();
            }
            else if(role=="Cashier")
            {
                SetupForCashier();
            }
            else if (role == "Salesman")
            {
                SetupForSalesman();
            }

            this.lblShowUserInfo.Text = this.role;
        }

        void SetupForAdmin()
        {
            btnDashboard.Enabled = true;
            btnMakeSell.Enabled = true;
            btnMasterProducts.Enabled = true;
            btnUser.Enabled = true;
            btnSellingHistory.Enabled = true;
            btnExpenses.Enabled = true;
            btnMasterStock.Enabled = true;
            btnSetting.Enabled = true;
        }

        void SetupForCashier()
        {
            btnDashboard.Enabled = true;
            btnMakeSell.Enabled = true;
            btnMasterProducts.Enabled = false;
            btnUser.Enabled = false;
            btnSellingHistory.Enabled = true;
            btnExpenses.Enabled = false;
            btnMasterStock.Enabled = true;
            btnSetting.Enabled = false;
        }

        void SetupForSalesman()
        {
            btnDashboard.Enabled = false;
            btnMakeSell.Enabled = true;
            btnMasterProducts.Enabled = false;
            btnUser.Enabled = false;
            btnSellingHistory.Enabled = true;
            btnExpenses.Enabled = false;
            btnMasterStock.Enabled = false;
            btnSetting.Enabled = false;
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ViewForm(new FormDashboard());
        }

        private void btnMakeSell_Click(object sender, EventArgs e)
        {
            FormMakeSale makeSale = new FormMakeSale();
            makeSale.ShowDialog();
        }

        private void btnMasterStock_Click(object sender, EventArgs e)
        {
            FormAddProduct addProduct = new FormAddProduct();
            addProduct.ShowDialog();
        }

        private void btnMasterProducts_Click(object sender, EventArgs e)
        {
            ViewForm(new FormMasterCategory());
        }

        private void btnMasterUser_Click(object sender, EventArgs e)
        {
            ViewForm(new FormUser());
        }


        private void btnSellingHistory_Click(object sender, EventArgs e)
        {
            ViewForm( new FormSellsHistory());
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            ViewForm(new FormExpense());
        }

        public void ViewForm(object _form)
        {
            if (pnlFormViwer.Controls.Count > 0) pnlFormViwer.Controls.Clear();
            {
                Form form = _form as Form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pnlFormViwer.Controls.Add(form);
                pnlFormViwer.Tag = form;
                form.Show();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
           // var decision =  MessageBox.Show("Do you want to close the application?","Confirmation",MessageBoxButtons.YesNo);

            if (MessageBox.Show("Do you want to close the application?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FormSetting setting = new FormSetting();
            setting.ShowDialog();
        }
    }
}
