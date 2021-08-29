using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Repository.InventoryProducts.Expense;

namespace FinalPoject.UserInterface.Dashboard
{
    public partial class FormDashboard : Form
    {
        private ExpenseRepo expenseRepo{get; set;}
        public FormDashboard()
        {
            InitializeComponent();
            this.expenseRepo = new ExpenseRepo();
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            lblExpLast7Day.Text = expenseRepo.GetLastWeekExpense();
            lblTotalExp.Text = expenseRepo.GetTotalExpense();

        }
    }
}
