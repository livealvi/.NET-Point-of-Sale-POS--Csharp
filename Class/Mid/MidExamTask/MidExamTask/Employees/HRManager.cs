using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    internal class HRManager : Employee
    {
        private double kpi;

        internal HRManager(string name, string id, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo, double kpi) : base(name, id, bloodGroup, salary, empPost, employeeInfo)
        {
            this.KPI = kpi;
        }

        internal double KPI
        {
            get { return this.kpi; }
            set { this.kpi = value; }
        }

        internal double TotalKPI()
        {
            return (this.kpi + this.Salary);
        }

        internal override void ShowEmployeeInfo()
        {
            base.ShowEmployeeInfo();
            Console.WriteLine("\tKPI: {0}", this.KPI);
            Console.WriteLine("\tSalary with KPI: {0}", this.TotalKPI());
        }
    }
}

