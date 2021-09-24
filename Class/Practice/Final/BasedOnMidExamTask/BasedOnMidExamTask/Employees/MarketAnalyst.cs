using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedOnMidExamTask.Employees
{
    internal class MarketAnalyst : Employee
    {
        private double commission;

        internal override string EmpID
        {
            get { return this.id; }
            set { this.id = "E-" + value + "-MA"; }
        }
        internal MarketAnalyst(string name,  string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo, double commission) : base(name, bloodGroup, salary, empPost, employeeInfo)
        {
            this.Commission = commission;
        }

        internal double Commission{ get; set; }

        internal override double TotalIncome()
        {
            return (this.Salary + this.Commission);
        }

        internal override void ShowEmployeeInfo()
        {
            base.ShowEmployeeInfo();
            Console.WriteLine("\tBonus: {0}", this.Commission);
        }
    }
}
