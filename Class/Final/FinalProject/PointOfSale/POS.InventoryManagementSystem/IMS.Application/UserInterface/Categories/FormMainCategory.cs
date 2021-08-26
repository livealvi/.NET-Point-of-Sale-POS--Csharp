using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts;
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormMainCategory : Form
    {
        private MainCategoriesRepo mainCateRepo{ get; set; }
        public FormMainCategory()
        {
            InitializeComponent();
            this.mainCateRepo = new MainCategoriesRepo();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvMainCate.AutoGenerateColumns = false;
            this.dgvMainCate.DataSource = this.mainCateRepo.GetAll(searchKey).ToList();
            this.dgvMainCate.ClearSelection();
            this.Refresh();
            this.RefreshContent();
        }

        public void RefreshContent()
        {
            this.txtMainCateId.Clear();
            this.txtMainCateName.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshContent();
            this.txtSearchCategories.Clear();
        }
        private void FormMainCategory_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void txtSearchCategories_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchCategories.Text);
        }

        private void dgvMainCate_DoubleClick(object sender, EventArgs e)
        {
            this.txtMainCateId.Text = this.dgvMainCate.CurrentRow.Cells["MainCategoryId"].Value.ToString();
            this.txtMainCateName.Text = this.dgvMainCate.CurrentRow.Cells["MainCategoryName"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MainCategories mcObj = this.FillEntity();
                if (mcObj == null)
                {
                    mcObj = new MainCategories();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var decision = this.mainCateRepo.DataExists(mcObj.MainCategoryId);

                if (decision)
                {
                    //Update
                    if (this.mainCateRepo.UpdateProduct(mcObj))
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
                    if (this.mainCateRepo.Save(mcObj))
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

        private MainCategories FillEntity()
        {
            //if (!this.IsValidToSave())
            //{
            //    return null;
            //}

            var mc = new MainCategories();

            if (this.txtMainCateId.Text == "")
            {
                mc.MainCategoryId = 0;
            }
            else
            {
                mc.MainCategoryId = Convert.ToInt32(this.txtMainCateId.Text);
            }

            mc.MainCategoryName = this.txtMainCateName.Text;
            return mc;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = this.dgvMainCate.CurrentRow.Cells["MainCategoryId"].Value.ToString();
            var name = this.dgvMainCate.CurrentRow.Cells["MainCategoryName"].Value.ToString();

            if (this.mainCateRepo.Delete(id))
            {
                MessageBox.Show(name + " - Delete Succeeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Error Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.PopulateGridView();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            string imgLoc = "";
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg) | *.jpg | PNG Files (*.png)| *.png | All Files (*.*) | *.* ";
                dlg.Title = "Select Main Category Picture";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    this.pbImage.ImageLocation = imgLoc;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

                throw;
            }
        }
    }
}
