using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Repository;

namespace FinalPoject.UserInterface.Dashboard
{
    public partial class FormLogin : Form
    {
        private UsersRepo usersRepo{get; set;}
        public FormLogin()
        {
            InitializeComponent();
            this.usersRepo = new UsersRepo();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role = usersRepo.GetRole(txtUserId.Text, txtPassword.Text);
            if (role=="Admin")
            {
                //MessageBox.Show("Logged in as admin");
                new FormStart(role).Show();
            }
            else if(role=="Cashier")
            {
                //MessageBox.Show("Logged in as Cashier");
                new FormStart(role).Show();

            }
            else if (role == null)
            {
                MessageBox.Show("Error login");
            }
            else
            {
                MessageBox.Show("Role Returned : "+role);
            }
        }
    }
}
