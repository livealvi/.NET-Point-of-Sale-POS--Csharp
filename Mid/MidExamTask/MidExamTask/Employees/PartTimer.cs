using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    internal class PartTimer : Employee
    {
        internal PartTimer(string name, string id, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo) : base(name, id, bloodGroup, salary, empPost, employeeInfo)
        {
        }
    }
}
