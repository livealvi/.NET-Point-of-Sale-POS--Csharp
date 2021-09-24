using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedOnMidExamTask.Employees
{
    internal class HRManager : Employee
    {
        private double kpi;

        internal HRManager(string name, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo, double kpi) : base(name,  bloodGroup, salary, empPost, employeeInfo)
        {
            this.KPI = kpi;
        }

        internal override string EmpID
        {
            get { return this.id; }
            set { this.id = "E-" + value + "-HRM"; }
        }

        internal double KPI{get; set;}

        internal double TotalKPI()
        {
            return (this.Salary + this.KPI);
        }

        internal override void ShowEmployeeInfo()
        {
            base.ShowEmployeeInfo();
            Console.WriteLine("\tKPI: {0}", this.KPI);
        }
    }
}

