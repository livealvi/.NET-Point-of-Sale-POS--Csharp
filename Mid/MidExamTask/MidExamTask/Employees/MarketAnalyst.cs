using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    class MarketAnalyst : Employee
    {
        private double commission;

        public MarketAnalyst()
        {
        }

        public MarketAnalyst(string name, string Id, string bloodGroup, double commission, double salary) : base(name, Id, bloodGroup)
        {
            this.Commission = commission;
            this.Salary = salary;
        }

        public double Commission
        {
            get { return this.commission; }

            set { this.commission = value; }
        }

        public double TotalCommission()
        {
            return (this.commission + this.Salary);
        }

        public void ShowEmpAddress()
        {
            Console.WriteLine("\n\n\t -------- Show Employee Infos --------\n");
            Console.WriteLine("\tPost - Market Analyst ");
            Console.WriteLine("\tID: {0}", this.EmpID);
            Console.WriteLine("\tName: {0}", this.EmpName);
            Console.WriteLine("\tBlood Group: {0}", this.EmpBloodGroup);
            Console.WriteLine("\tSalary : {0}", this.Salary);
            Console.WriteLine("\tBonus: {0}", this.Commission);
            Console.WriteLine("\tSalary with Commission: {0}", this.TotalCommission());
            Console.Write("\tBirth ");
            this.EmployeeInfo.BirthDate.ShowDate();
            Console.Write("\tJoin ");
            this.EmployeeInfo.JoiningDate.ShowDate();

        }
    }
}
