using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Entity;
using IMS.Entity.InventoryProducts;
using IMS.Repository;

namespace FinalPoject
{
    public partial class FormSecondCategory : Form
    {
        private SecondCategoriesReop secondCateReop{get; set;}
        private MainCategoriesRepo   mainCateRepo  {get; set;}
        public FormSecondCategory()
        {
            InitializeComponent();
            this.secondCateReop = new SecondCategoriesReop();
            this.mainCateRepo = new MainCategoriesRepo();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvSecondCate.AutoGenerateColumns = false;
            this.dgvSecondCate.DataSource = this.secondCateReop.GetAll(searchKey).ToList();
            this.dgvSecondCate.ClearSelection();
            this.Refresh();
            this.RefreshContent();
            this.MainCategoryIdToName();
        }

        public void MainCategoryIdToName()
        {
            this.cmbMainCate.Items.Clear();
            this.cmbMainCate.Items.Add("--Not Selected--");
            this.cmbMainCate.SelectedIndex = cmbMainCate.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.mainCateRepo.LoadComboMainCategoryName().Rows)
            {
                this.cmbMainCate.Items.Add(row["MainCategoryName"].ToString());
            }
        }

        public void RefreshContent()
        {
            this.txtSecondCateId.Clear();
            this.txtSecondCateName.Clear();
            this.cmbMainCate.SelectedIndex = -1;
        }

        //private void ItemFound()
        //{
        //    this.lblTotal.Text = "Total Item: " + this.dgvSecondCate.RowCount.ToString();
        //} 

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshContent();
            this.txtSearchCategories.Clear();
            //this.ItemFound();
        }

        private void FormSecondCategory_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void txtSearchCategories_TextChanged_1(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchCategories.Text);
            //if (this.txtSearchCategories.Text == String.Empty)
            //    this.lblTotal.Text = "Serach Found: " + this.dgvSecondCate.RowCount.ToString();
           
        }

        private void dgvSecondCate_DoubleClick(object sender, EventArgs e)
        {
            this.txtSecondCateId.Text = this.dgvSecondCate.CurrentRow.Cells["SecondCategoryId"].Value.ToString();
            this.txtSecondCateName.Text = this.dgvSecondCate.CurrentRow.Cells["SecondCategoryName"].Value.ToString();
            this.cmbMainCate.Text = this.dgvSecondCate.CurrentRow.Cells["MainCategoryName"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SecondCategories scObj = this.FillEntity();
                if (scObj == null)
                {
                    scObj = new SecondCategories();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var decision = this.secondCateReop.DataExists(scObj.SecondCategoryId);

                if (decision)
                {
                    //Update
                    if (this.secondCateReop.UpdateProduct(scObj))
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
                    if (this.secondCateReop.Save(scObj))
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

        private SecondCategories FillEntity()
        {
            //if (!this.IsValidToSave())
            //{
            //    return null;
            //}

            var sC = new SecondCategories();

            if (this.txtSecondCateId.Text == "")
            {
                sC.SecondCategoryId = 0;
            }
            else
            {
                sC.SecondCategoryId = Convert.ToInt32(this.txtSecondCateId.Text);
            }

            sC.SecondCategoryName = this.txtSecondCateName.Text;
            sC.MainCategoryId = mainCateRepo.GetMainCategoryId(this.cmbMainCate.Text);
            return sC;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = this.dgvSecondCate.CurrentRow.Cells["SecondCategoryId"].Value.ToString();
            var name = this.dgvSecondCate.CurrentRow.Cells["SecondCategoryName"].Value.ToString();

            if (this.secondCateReop.Delete(id))
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddMainCate_Click(object sender, EventArgs e)
        {
            FormMainCategory mainCategory = new FormMainCategory();
            mainCategory.ShowDialog();
        }
    }
}
