using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPoject.UserInterface.Dashboard
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void lblForgetPassword_MouseHover(object sender, EventArgs e)
        {
            this.lblForgetPassword.ForeColor = Color.FromArgb(55, 148, 247);
        }

        private void lblForgetPassword_MouseLeave(object sender, EventArgs e)
        {
            this.lblForgetPassword.ForeColor = Color.FromArgb(196, 189, 237);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
