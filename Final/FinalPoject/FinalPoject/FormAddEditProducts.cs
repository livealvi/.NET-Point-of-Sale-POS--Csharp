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
    public partial class FormAddEditProducts : Form
    {
        public FormAddEditProducts()
        {
            InitializeComponent();
        }

        private void formClose_Click(object sender, EventArgs e)
        {
            this.ShowProducts();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.ShowProducts();
        }

        private void ShowProducts()
        {
            FormProducts formProducts = new FormProducts();
            this.Hide();
        }
    }
}
