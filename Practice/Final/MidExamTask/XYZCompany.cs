using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    internal class XYZCompany
    {
        private static int count = 0;
        private Employee[] employeesList = new Employee[3000];

        internal void AddEmployee(Employee employee)
        {
            this.employeesList[count] = employee;
            count++;
        }
        internal void ShowAll()
        {
            int index = 0;

            while (index < count)
            {
                employeesList[index].ShowEmployeeInfo(); // runtime polymorphism .ShowEmployeeInfo()
                Console.WriteLine();
                index++;
            }
        }

    }
}
