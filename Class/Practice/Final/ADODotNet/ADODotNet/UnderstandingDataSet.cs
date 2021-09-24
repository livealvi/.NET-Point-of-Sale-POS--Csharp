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
    public partial class UnderstandingDataSet : Form
    {
        DataTable dataTable;
        DataColumn dataColumn;
        DataRow dataRow;
        DataSet dataSet;

        public UnderstandingDataSet()
        {
            InitializeComponent();
        }

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
            dataRow[2] = 10;
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow[0] = 103;
            dataRow[1] = "Ahmed";
            dataRow[2] = 20;
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow[0] = 104;
            dataRow[1] = "Alex";
            dataRow[2] = 20;
            dataTable.Rows.Add(dataRow);
            #endregion

            return dataTable;
        }

        DataTable GetDeprtmentTable()
        {
            dataTable = new DataTable("Department");

            #region Department DataTable

            //Adding Columns
            dataColumn = new DataColumn("DeptId", typeof(int));
            dataTable.Columns.Add(dataColumn);
            dataTable.PrimaryKey = new DataColumn[] { dataColumn };

            dataColumn = new DataColumn("DeptName", typeof(string));
            dataTable.Columns.Add(dataColumn);

            //Adding Rows
            dataRow = dataTable.NewRow();
            dataRow[0] = 10;
            dataRow[1] = "Admin";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow[0] = 20;
            dataRow[1] = "HR";
            dataTable.Rows.Add(dataRow);
            #endregion

            return dataTable;
        }

        DataSet GenerateDataSet()
        {
            DataTable emp = GetEmployeeTable();
            DataTable dept = GetDeprtmentTable();

            dataSet = new DataSet("MyDS");
            dataSet.Tables.Add(emp);  // index is - 0
            dataSet.Tables.Add(dept); // index is - 1

            DataColumn col_pk = dataSet.Tables[1].Columns[0];
            DataColumn col_fk = dataSet.Tables["Employee"].Columns["DeptId"];
            DataRelation dataRelation = new DataRelation("Emp_Dept_Rel", col_pk, col_fk);
            dataSet.Relations.Add(dataRelation);

            return dataSet;
        }

        private void UnderstandingDataSet_Load(object sender, EventArgs e)
        {
            DataSet MyDs = GenerateDataSet();
            dataGridView1.DataSource = MyDs.Tables[0];
            dataGridView2.DataSource = MyDs.Tables[1];
        }
    }
}
