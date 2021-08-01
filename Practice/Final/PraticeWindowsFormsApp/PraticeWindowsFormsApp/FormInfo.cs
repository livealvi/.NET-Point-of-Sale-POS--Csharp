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
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.txtOutputUsername.Text = this.txtUsername.Text;
            this.lblPassword.Text = this.txtPassword.Text;
            this.lblDepartment.Text = this.cmbDepartment.Text;
            this.lblDOB.Text = this.dtpDOB.Text;

            //this.lblPassword.Visible = true;

            if (this.rbBachelors.Checked)
            {
                this.lblType.Text = this.rbBachelors.Text;
            }
            else if (this.rbMasters.Checked)
            {
                this.lblType.Text = this.rbMasters.Text;
            }

            if (this.rbMale.Checked)
            {
                this.lblGender.Text = "Male";
            }
            else if (this.rbFemale.Checked)
            {
                this.lblGender.Text = "Female";
            }

            this.pnlOutput.Visible = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtOutputUsername.Text = "";
            this.lblPassword.Text = "OutputPassword";
            //this.lblDepartment.Text = "OutputDepartment";
            this.cmbDepartment.SelectedIndex = -1;
            this.lblDOB.Text = "OutputDOB";
            this.lblType.Text = "OutputType";
            this.lblGender.Text = "OutputGender";
            this.rbMale.Checked = false;
            this.rbFemale.Checked = false;

            //this.lblPassword.Visible = false;
            this.pnlOutput.Visible = false;
        }
    }
}
