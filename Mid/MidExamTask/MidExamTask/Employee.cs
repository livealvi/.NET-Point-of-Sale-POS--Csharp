using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MidExamTask.Employees;

namespace MidExamTask.Employees
{
    class Employee
    {
        private string Id;
        private string name;
        private string bloodGroup;
        private EmployeeInfo employeeInfo;
        private double salary;

        public Employee()
        {

        }

        public Employee(string name, string Id, string bloodGroup)
        {
            this.EmpName = this.name;
            this.EmpID = Id;
            this.EmpBloodGroup = bloodGroup;
        }

        public string EmpName
        {
            get { return this.name; }

            set { this.name = value; }
        }

        public string EmpID
        {
            get { return this.Id; }

            set { this.Id = value; }
        }

        public string EmpBloodGroup
        {
            get { return this.bloodGroup; }

            set { this.bloodGroup = value; }
        }

        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
            
        }

        internal EmployeeInfo EmployeeInfo
        {
            get { return this.employeeInfo; }
            set { this.employeeInfo = value; }
        }

    }
}
