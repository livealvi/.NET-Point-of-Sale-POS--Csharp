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
                FormStart formStart = new FormStart  (role,this);
                formStart.Visible = true;
                this.Visible = false;
            }
            else if(role=="Cashier")
            {
                new FormStart(role, this).Show();
                FormStart formStart = new FormStart(role, this);
                formStart.Visible = true;
                this.Visible = false;
            }
            else if (role == "Salesman")
            {
                new FormStart(role, this).Show();
                FormStart formStart = new FormStart(role, this);
                formStart.Visible = true;
                this.Visible = false;
            }
            else if (role == null)
            {
                MessageBox.Show("UserID & Password Incorrect", "Login Filed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Role Returned : "+role);
            }
        }
    }
}
