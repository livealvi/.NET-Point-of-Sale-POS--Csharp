using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasedOnMidExamTask.Employees;

namespace BasedOnMidExamTask.Employees
{
    internal class PartTimer : Employee
    {
        internal override string EmpID
        {
            get { return this.id; }
            set { this.id = "E-" + value + "-PA"; }
        }
        internal PartTimer(string name,  string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo) : base(name, bloodGroup, salary, empPost, employeeInfo)
        {
        }
    }
}
