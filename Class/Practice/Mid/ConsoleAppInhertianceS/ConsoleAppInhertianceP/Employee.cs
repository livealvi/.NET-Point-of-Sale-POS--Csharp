using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInhertianceP
{
    internal class Employee : Person
    {
        private double salary;
        internal double Salary
        {
            get { return this.salary; }

            set { this.salary = value; }
        }

        internal Employee(int id, string name, string bloodGroup, double salary) : base(id ,name, bloodGroup)
        {
            this.Salary = salary;
        }
        internal override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Salary: {0}", this.Salary);
        }
    }
}
