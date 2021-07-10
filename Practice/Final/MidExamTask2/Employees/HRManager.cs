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


        internal override string EmpId
        {
            set
            {
                this.id = "E-" + value + "-HR";
            }
        }

        internal HRManager(string name, string bloodGroup, double salary, double kpi, string empPost, EmployeeInfo employeeInfo) : base(name,  bloodGroup, salary, empPost, employeeInfo)
        {
            this.KPI = kpi;
            this.Salary = salary;
        }

        internal double KPI
        {
            get {return this.kpi;}

            set {this.kpi = value;}
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

        //internal override void M1()
        //{

        //}
    }
}

