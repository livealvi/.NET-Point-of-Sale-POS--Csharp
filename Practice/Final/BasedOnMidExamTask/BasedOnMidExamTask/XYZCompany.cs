using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedOnMidExamTask.Employees
{
    internal class XYZCompany
    {
        private static Employee[] employeesList = new Employee[3000];
        private static int count = 0;

        internal static void AddEmployee(Employee employee)
        {
            employeesList[count] = employee;
            count++;
        }

        internal static void ShowAll()
        {
            int index = 0;
            while (index < count)
            {
                if (employeesList[index] == null)
                {
                    index++;
                    continue;
                }
                employeesList[index].ShowEmployeeInfo(); // runtime polymorphism .ShowEmployeeInfo()
                Console.WriteLine();
                index++;
            }
        }

        internal static bool Search(string key, out int counter)
        {
            bool found = false;

            int index = 0;
            while (index < count)
            {
                if(key.Equals(employeesList[index].EmpID))
                {
                    Console.WriteLine("\n\n\t-------- Employee Search ------------\n");
                    Console.Write("\tEmployee Found");
                    employeesList[index].ShowEmployeeInfo();
                    Console.WriteLine();
                    found = true;
                    counter = index;
                    return found;
                }
                index++;
            }
            if (!found) 
                Console.WriteLine("\n\n\t-------- Employee Search ------------\n");
            Console.WriteLine("\tNot Found\n");
            Console.WriteLine("\t-------------------------------------\n");
            counter = -1;
                return found;
        }

        internal static void DeleteEmployee(string key)
        {
            int indexNumber;
            bool decision = Search(key, out indexNumber);
            if (decision)
            {
                Console.WriteLine("\t-------------------------------------\n");
                employeesList[indexNumber] = null;
                Console.WriteLine("\tData Deleted Succeed.\n");
                Console.WriteLine("\t-------------------------------------\n");
            }
            ShowAll();
        }

    }
}
