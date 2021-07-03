using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    class ITExecutive : Employee
    {

        private double bonus;

        public ITExecutive()
        {
        }

        public ITExecutive(string name, string Id, string bloodGroup, double bonus, double salary) : base(name, Id, bloodGroup)
        {
            this.Bonus = bonus;
            this.Salary = salary;
        }

        public double Bonus
        {
            get { return this.bonus; }

            set { this.bonus = value; }
        }

        public double TotalSalary()
        {
            return (this.bonus + this.Salary);
        }

        public void ShowEmpAddress() 
        {
            Console.WriteLine("\n\n\t-------- Show Employee Infos --------\n");
            Console.WriteLine("\tPost - IT Executive");
            Console.WriteLine("\tID: {0}", this.EmpID);
            Console.WriteLine("\tName: {0}", this.EmpName);
            Console.WriteLine("\tBlood Group: {0}", this.EmpBloodGroup);
            Console.WriteLine("\tSalary : {0}", this.Salary);
            Console.WriteLine("\tBonus: {0}", this.Bonus);
            Console.WriteLine("\tSalary with bonus: {0}", this.TotalSalary());
            Console.Write("\tBirth ");
            this.EmployeeInfo.BirthDate.ShowDate();
            Console.Write("\tJoin ");
            this.EmployeeInfo.JoiningDate.ShowDate();

        }
    }
}
