using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADODotNet
{
    public partial class DisconnectedArchitecture : Form
    {
         DataTable dataTable;
         DataColumn dataColumn;
         DataRow dataRow;

         //DataGridView
         DataTable GetEmployeeTable()
        {
            dataTable = new DataTable("Employee");

            #region Employee DataTable
            //Adding Columns
            dataColumn = new DataColumn("EmpId", typeof(int));
            dataTable.Columns.Add(dataColumn);
            dataTable.PrimaryKey = new DataColumn[] { dataColumn };

            dataColumn = new DataColumn("EmpName", typeof(string));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("DeptId", typeof(int));
            dataTable.Columns.Add(dataColumn);

            //Adding Rows
            dataRow = dataTable.NewRow();
            dataRow[0] = 101;
            dataRow[1] = "Alvi";
            dataRow[2] = 10;
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow[0] = 102;
            dataRow[1] = "Hasan";
            dataRow[2] = 20;
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow[0] = 103;
            dataRow[1] = "Ahmed";
            dataRow[2] = 30;
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow[0] = 104;
            dataRow[1] = "Alex";
            dataRow[2] = 40;
            dataTable.Rows.Add(dataRow);
            #endregion

            return dataTable;
        }

        public DisconnectedArchitecture()
        {
            InitializeComponent();
        }

        private void DisconnectedArchitecture_Load(object sender, EventArgs e)
        {
            DataTable EmpTable = GetEmployeeTable();
            dataGridView1.DataSource = EmpTable;
        }
    }
}
