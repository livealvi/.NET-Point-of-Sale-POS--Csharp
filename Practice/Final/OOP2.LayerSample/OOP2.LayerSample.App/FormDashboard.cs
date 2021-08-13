using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP2.LayerSample.Repository;

namespace OOP2.LayerSample.App
{
    public partial class FormDashboard : Form
    {
        private ProductRepository productRepo {get; set;}
        public FormDashboard()
        {
            InitializeComponent();
            this.productRepo = new ProductRepository();
        }

        private void PopulateGridView(string searchKey = null)
        {
            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.DataSource = this.productRepo.GetAll(searchKey).ToList();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        { 
            this.PopulateGridView();
        }
    }
}
