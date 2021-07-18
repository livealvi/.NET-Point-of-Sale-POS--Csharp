using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedOnMidExamTask.Employees
{
    internal class ITExecutive : Employee
    {
        private double bonus;

        internal ITExecutive(string name, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo, double bonus) : base(name, bloodGroup, salary, empPost, employeeInfo)
        {
            this.Bonus = bonus;
        }
        internal override string EmpID
        {
            get { return this.id; }
            set { this.id = "E-" + value + "-ITE"; }
        }
        internal double Bonus{get; set;}
        internal override double TotalIncome()
        {
            return (this.Salary + this.Bonus);
        }
        internal override void ShowEmployeeInfo() 
        {
            base.ShowEmployeeInfo();
            Console.WriteLine("\tBonus: {0}", this.Bonus);
        }
    }
}
