using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace FinalPoject
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMakeSell_Click(object sender, EventArgs e)
        {

        }

        private void btnMasterStock_Click(object sender, EventArgs e)
        {

        }

        private void btnMasterProducts_Click(object sender, EventArgs e)
        {
            ViewForm(new FormProductsMaster());
        }

        private void btnMasterUser_Click(object sender, EventArgs e)
        {
            ViewForm(new FormUser());
        }

        private void btnMasterCustomer_Click(object sender, EventArgs e)
        {

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

    }
}
