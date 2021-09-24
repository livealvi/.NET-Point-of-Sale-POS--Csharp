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
    public partial class Form2 : Form
    {
        private Form1 F1{get; set;}
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f1, string info) : this()
        {
            //InitializeComponent();
            this.F1 = f1;
            this.lblInfo.Text = info;
        }


        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //Form1 f1 = new Form1();
            //f1.Show();
            this.F1.Visible = true;
            this.Hide();
        }
    }
}
