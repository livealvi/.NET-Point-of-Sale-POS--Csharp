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
    public partial class FormThirdCategory : Form
    {
        private ThirdCategoriesRepo  thirdCategoriesRepo {get; set;}
        private SecondCategoriesReop secondCategoriesReop{get; set;}
        public FormThirdCategory()
        {
            InitializeComponent();
            this.thirdCategoriesRepo = new ThirdCategoriesRepo();
            this.secondCategoriesReop = new SecondCategoriesReop();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvThirdCate.AutoGenerateColumns = false;
            var a = this.dgvThirdCate.DataSource = this.thirdCategoriesRepo.GetAll(searchKey).ToList();
            this.dgvThirdCate.ClearSelection();
            this.Refresh();
            this.RefreshContent();
            this.SecondCategoryIdToName();
        }


        private void SecondCategoryIdToName()
        {
            this.cmbSecondCateName.Items.Clear();
            this.cmbSecondCateName.Items.Add("--Not Selected--");
            this.cmbSecondCateName.SelectedIndex = cmbSecondCateName.FindStringExact("--Not Selected--");
            foreach (DataRow row in this.secondCategoriesReop.LoadComboMainCategoryName().Rows)
            {
                this.cmbSecondCateName.Items.Add(row["SecondCategoryName"].ToString());
            }
        }

        public void RefreshContent()
        {
            this.txtThirdCateId.Clear();
            this.txtThirdCateName.Clear();
            this.cmbSecondCateName.SelectedIndex = -1;
        }

        private void FormThirdCategory_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void txtSearchCategories_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchCategories.Text);
        }

        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshContent();
            this.txtSearchCategories.Clear();
        }

        private void dgvThirdCate_DoubleClick(object sender, EventArgs e)
        {
            this.txtThirdCateId.Text = this.dgvThirdCate.CurrentRow.Cells["ThirdCategoryId"].Value.ToString();
            this.txtThirdCateName.Text = this.dgvThirdCate.CurrentRow.Cells["ThirdCategoryName"].Value.ToString();
            this.cmbSecondCateName.Text = this.dgvThirdCate.CurrentRow.Cells["SecondCategoryName"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ThirdCategories tcObj = this.FillEntity();
                if (tcObj == null)
                {
                    tcObj = new ThirdCategories();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var decision = this.thirdCategoriesRepo.DataExists(tcObj.ThirdCategoryId);

                if (decision)
                {
                    //Update
                    if (this.thirdCategoriesRepo.UpdateProduct(tcObj))
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
                    if (this.thirdCategoriesRepo.Save(tcObj))
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

        private ThirdCategories FillEntity()
        {
            //if (!this.IsValidToSave())
            //{
            //    return null;
            //}

            var thC = new ThirdCategories();

            if (this.txtThirdCateId.Text == "")
            {
                thC.ThirdCategoryId = 0;
            }
            else
            {
                thC.ThirdCategoryId = Convert.ToInt32(this.txtThirdCateId.Text);
            }
            thC.ThirdCategoryName = this.txtThirdCateName.Text;
            thC.SecondCategoryId = secondCategoriesReop.GetSecondCategoryId(this.cmbSecondCateName.Text);
            return thC;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = this.dgvThirdCate.CurrentRow.Cells["ThirdCategoryId"].Value.ToString();
            var name = this.dgvThirdCate.CurrentRow.Cells["ThirdCategoryName"].Value.ToString();

            if (this.thirdCategoriesRepo.Delete(id))
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

        private void btnAddSecondCate_Click(object sender, EventArgs e)
        {
            FormSecondCategory secondCategory = new FormSecondCategory();
            secondCategory.ShowDialog();
        }
    }
}
