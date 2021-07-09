using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidExamTask.Employees;

namespace MidExamTask.Employees
{
    internal class PartTimer : Employee
    {
        internal PartTimer(string name,  string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo) : base(name, bloodGroup, salary, empPost, employeeInfo)
        {
        }
    }
    //internal override void M1()
    //{

    //}
}
