using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PraticeWindowsFormsApp
{
    public partial class FormAdmin : Form
    {
        private FormLogin F1{get; set;}

        public FormAdmin()
        {
            InitializeComponent();
        }
        public FormAdmin(FormLogin f1, string info) : this()
        {
            //InitializeComponent();
            this.F1 = f1;
            this.lblInfo.Text = info;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logout Done");
            this.F1.Show();
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Closing App");
            Application.Exit();
        }
    }
}
