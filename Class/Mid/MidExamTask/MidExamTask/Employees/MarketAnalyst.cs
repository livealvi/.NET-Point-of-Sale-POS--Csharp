using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    internal class MarketAnalyst : Employee
    {
        private double commission;

        internal double Commission
        {
            get { return this.commission; }
            set { this.commission = value; }
        }

        internal double TotalCommission()
        {
            return (this.commission + this.Salary);
        }

        internal MarketAnalyst(string name, string id, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo, double commission) : base(name, id, bloodGroup, salary, empPost, employeeInfo)
        {
            this.Commission = commission;
        }

        internal override void ShowEmployeeInfo()
        {
            base.ShowEmployeeInfo();
            Console.WriteLine("\tBonus: {0}", this.Commission);
            Console.WriteLine("\tSalary with Commission: {0}", this.TotalCommission());
        }
    }
}
