﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Entity;
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormUser : Form
    {
        private UsersRepo usersRepo{ get; set; }
        public FormUser()
        {
            InitializeComponent();
            this.usersRepo = new UsersRepo();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvUser.AutoGenerateColumns = false;
            this.dgvUser.DataSource = this.usersRepo.GetAll(searchKey).ToList();
            this.dgvUser.ClearSelection();
            this.Refresh();
            this.RefreshContent();
        }

        public void RefreshContent()
        {
            this.txtId.Clear();
            this.txtTag.Clear();
            this.txtFirstName.Clear();
            //
            this.txtLastName.Clear();
            this.txtAge.Clear();
            this.cmbGender.SelectedIndex = 0;
            this.cmbRole.SelectedIndex = 0;
            this.txtSalary.Clear();
            this.dtpJoinDate.Text = "";
            this.dtpBirthDate.Text = "";
            this.txtNID.Text = "";
            this.txtPhone.Clear();
            this.txtHomeTown.Clear();
            this.txtCurrentCity.Clear();
            this.cmbDivision.SelectedIndex = 0;
            this.cmbBlood.SelectedIndex = 0;
            this.txtPostalCode.Clear();
        }
        private void FormUser_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }


        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshContent();
            this.txtSearch.Clear();
        }

        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = this.dgvUser.CurrentRow.Cells["UserId"].Value.ToString();
            this.txtTag.Text = this.dgvUser.CurrentRow.Cells["UserTag"].Value.ToString();
            this.txtFirstName.Text = this.dgvUser.CurrentRow.Cells["FirstName"].Value.ToString();
            this.txtLastName.Text = this.dgvUser.CurrentRow.Cells["LastName"].Value.ToString();
            this.txtAge.Text = this.dgvUser.CurrentRow.Cells["Age"].Value.ToString();
            this.cmbGender.Text = this.dgvUser.CurrentRow.Cells["Gender"].Value.ToString();
            this.cmbRole.Text = this.dgvUser.CurrentRow.Cells["Role"].Value.ToString();
            this.txtSalary.Text = this.dgvUser.CurrentRow.Cells["Salary"].Value.ToString();
            //this.dtpJoinDate.Text = this.dgvUser.CurrentRow.Cells["JoinDate"].Value.ToString();
            //this.dtpBirthDate.Text = this.dgvUser.CurrentRow.Cells["Birthdate"].Value.ToString();
            this.txtNID.Text = this.dgvUser.CurrentRow.Cells["NID"].Value.ToString();
            this.txtPhone.Text = this.dgvUser.CurrentRow.Cells["Phone"].Value.ToString();
            this.txtHomeTown.Text = this.dgvUser.CurrentRow.Cells["HomeTown"].Value.ToString();
            this.txtCurrentCity.Text = this.dgvUser.CurrentRow.Cells["CurrentCity"].Value.ToString();
            this.cmbDivision.Text = this.dgvUser.CurrentRow.Cells["Division"].Value.ToString();
            this.cmbBlood.Text = this.dgvUser.CurrentRow.Cells["BloodGroup"].Value.ToString();
            this.txtPostalCode.Text = this.dgvUser.CurrentRow.Cells["PostalCode"].Value.ToString();
        }

        
        private Users FillEntity()
        {
            //if (!this.IsValidToSave())
            //{
            //    return null;
            //}

            var users = new Users();

            if (this.txtId.Text == "")
            {
                users.UserId = 0;
            }
            else
            {
                users.UserId = Convert.ToInt32(this.txtId.Text);
            }

            //uc.MainCategoryName = this.txtId.Text;
            users.FirstName = this.txtFirstName.Text;
            users.LastName = this.txtLastName.Text;
            users.Age = Convert.ToInt32(this.txtAge.Text);
            users.Gender = cmbGender.Text;
            users.Role = cmbRole.Text;
            users.Salary = Convert.ToDouble(txtSalary.Text);
            //users.JoinDate = dtpJoinDate.Text;
            //users.Birthdate = Convert.ToDateTime(new DateTime("year"));
            users.NID = txtNID.Text; ;
            users.Phone = txtPhone.Text; ;
            users.HomeTown = txtHomeTown.Text; ;
            users.CurrentCity = txtCurrentCity.Text;
            users.Division = cmbDivision.Text;
            users.BloodGroup = cmbBlood.Text;
            users.PostalCode = Convert.ToInt32(txtPostalCode.Text);
            return users;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Users ucObj = this.FillEntity();
                if (ucObj == null)
                {
                    ucObj = new Users();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var decision = this.usersRepo.DataExists(ucObj.UserId);

                if (decision)
                {
                    //Update
                    if (this.usersRepo.UpdateUser(ucObj))
                    {
                        MessageBox.Show("Update Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    //Save
                    if (this.usersRepo.Save(ucObj))
                    {
                        MessageBox.Show("Save Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Save Failed");
                    }
                }
                Refresh();
                this.PopulateGridView();
            }

            catch (Exception exception)
            {
                MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = this.dgvUser.CurrentRow.Cells["UserId"].Value.ToString();
            var Fname = this.dgvUser.CurrentRow.Cells["FirstName"].Value.ToString();
            var Lname = this.dgvUser.CurrentRow.Cells["LastName"].Value.ToString();

            if (this.usersRepo.Delete(id))
            {
                MessageBox.Show(Fname + " " + Lname + " - Delete Succeeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Error Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.PopulateGridView();
        }
    }
}