using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Entity.InventoryProducts.Expense;
using IMS.Repository.InventoryProducts.Expense;

namespace FinalPoject.UserInterface.Exp
{
    public partial class FormExpense : Form
    {
        private ExpenseRepo expenseRepo = new ExpenseRepo();
        public FormExpense()
        {
            InitializeComponent();
            this.expenseRepo = new ExpenseRepo();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvExpenses.AutoGenerateColumns = false;
            this.dgvExpenses.DataSource = this.expenseRepo.GetAll(searchKey).ToList();
            this.dgvExpenses.ClearSelection();
            this.Refresh();
            this.RefreshContent();
        }
        private void Expense_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        public void RefreshContent()
        {
            this.txtExpenseId.Clear();
            this.txtExpensesName.Clear();
            this.txtExpenseAmount.Clear();
            this.dtpExpenseDate.Text = "";
        }

        private void txtSearchExpenses_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchExpenses.Text);
        }

        private void dgvExpenses_DoubleClick(object sender, EventArgs e)
        {
            this.txtExpenseId.Text = this.dgvExpenses.CurrentRow.Cells["ExpenseId"].Value.ToString();
            this.txtExpensesName.Text = this.dgvExpenses.CurrentRow.Cells["ExpenseName"].Value.ToString();
            this.txtExpenseAmount.Text = this.dgvExpenses.CurrentRow.Cells["ExpenseAmount"].Value.ToString();
            this.dtpExpenseDate.Text = this.dgvExpenses.CurrentRow.Cells["ExpenseDate"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Expenses exObj = this.FillEntity();
                if (exObj == null)
                {
                    exObj = new Expenses();
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var decision = this.expenseRepo.DataExists(exObj.ExpenseId);

                if (decision)
                {
                    //Update
                    if (this.expenseRepo.UpdateExpenses(exObj))
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
                    if (this.expenseRepo.Save(exObj))
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

        private Expenses FillEntity()
        {
            var expenses = new Expenses();

            if (this.txtExpenseId.Text == "")
            {
                expenses.ExpenseId = 0;
            }
            else
            {
                expenses.ExpenseId = Convert.ToInt32(this.txtExpenseId.Text);
            }

            expenses.ExpenseName = this.txtExpensesName.Text;
            expenses.ExpenseAmount = Convert.ToDouble(this.txtExpenseAmount.Text);
            expenses.ExpenseDate = Convert.ToDateTime(Convert.ToDateTime(dtpExpenseDate.Value).ToString("yyyy-MM-dd"));
            return expenses;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = this.dgvExpenses.CurrentRow.Cells["ExpenseId"].Value.ToString();
            var name = this.dgvExpenses.CurrentRow.Cells["ExpenseName"].Value.ToString();

            if (this.expenseRepo.Delete(id))
            {
                MessageBox.Show(name + " " + "- Delete Succeeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Error Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.PopulateGridView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshContent();
            this.txtSearchExpenses.Clear();
        }
    }
}
