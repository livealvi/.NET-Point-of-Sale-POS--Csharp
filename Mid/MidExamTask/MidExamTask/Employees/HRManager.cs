using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    class HRManager : Employee
    {
        private double kpi;

        public HRManager()
        {
        }

        public HRManager(string name, string Id, string bloodGroup, double commission, double salary) : base(name, Id, bloodGroup)
        {
            this.KPI = kpi;
            this.Salary = salary;
        }

        public double KPI
        {
            get { return this.kpi; }

            set { this.kpi = value; }
        }

        public double TotalKPI()
        {
            return (this.kpi + this.Salary);
        }

        public void ShowEmpAddress()
        {
            Console.WriteLine("\n\n\t -------- Show Employee Infos --------\n");
            Console.WriteLine("\tPost - HR Manager ");
            Console.WriteLine("\tID: {0}", this.EmpID);
            Console.WriteLine("\tName: {0}", this.EmpName);
            Console.WriteLine("\tBlood Group: {0}", this.EmpBloodGroup);
            Console.WriteLine("\tSalary : {0}", this.Salary);
            Console.WriteLine("\tKPI: {0}", this.KPI);
            Console.WriteLine("\tSalary with KPI: {0}", this.TotalKPI());
            Console.Write("\tBirth ");
            this.EmployeeInfo.BirthDate.ShowDate();
            Console.Write("\tJoin ");
            this.EmployeeInfo.JoiningDate.ShowDate();
        }
    }
}

