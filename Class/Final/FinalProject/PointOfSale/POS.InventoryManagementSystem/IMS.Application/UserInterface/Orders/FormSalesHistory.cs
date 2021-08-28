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

namespace FinalPoject
{
    public partial class FormSellsHistory : Form
    {
        private OrdersRepo ordersRepo{get; set;}
        public FormSellsHistory()
        {
            InitializeComponent();
            this.ordersRepo = new OrdersRepo();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvSellHistory.AutoGenerateColumns = false;
            this.dgvSellHistory.DataSource = this.ordersRepo.GetAllOrderHistory(searchKey);
            this.dgvSellHistory.ClearSelection();
            this.Refresh();
            this.lblTotalItemResult.Text = this.dgvSellHistory.RowCount.ToString();
        }

        private void FormSellsHistory_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void RefreshContent()
        {
            this.PopulateGridView();
            this.txtSearchSellHistory.Clear();
        }

        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            this.RefreshContent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshContent();
        }

        private void txtSearchSellHistory_TextChanged(object sender, EventArgs e)
        {
            this.PopulateGridView(this.txtSearchSellHistory.Text);
        }
    }
}
