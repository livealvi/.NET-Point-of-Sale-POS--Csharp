using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    internal class ITExecutive : Employee
    {
        private double bonus;

        internal ITExecutive(string name, string id, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo, double bonus) : base(name, id, bloodGroup, salary, empPost, employeeInfo)
        {
            this.Bonus = bonus;
        }
        internal double Bonus
        {
            get { return this.bonus; }
            set { this.bonus = value; }
        }
        internal double TotalSalary()
        {
            return (this.bonus + this.Salary);
        }
        internal override void ShowEmployeeInfo() 
        {
            base.ShowEmployeeInfo();
            Console.WriteLine("\tBonus: {0}", this.Bonus);
            Console.WriteLine("\tSalary with bonus: {0}", this.TotalSalary());
        }
    }
}
