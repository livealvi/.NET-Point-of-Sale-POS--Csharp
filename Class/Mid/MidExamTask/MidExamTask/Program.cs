using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidExamTask.Employees;

namespace MidExamTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n\n======= Welcome to Employees Management System =======\n");

            Employee[] emp = new Employee[5];
            emp[0] = new Employee("FirstName LastName", "E-000", "Unknown", 0000000, "Employee", new EmployeeInfo(new EmpResidenceInfo("Blank", "Blank", "01000000000"), new Date(0000, "Blank", 00), new Date(0000, "Blank", 00)));
            emp[1] = new HRManager("Alvi Hasan", "E-0001", "B+", 75000, "HR Manager", new EmployeeInfo(new EmpResidenceInfo("Kowtali", "Jessore", "01900000000"), new Date(1997, "OCT", 25), new Date(2021, "Jan", 11)), 6000);
            emp[2] = new ITExecutive("Hasan Mahamud", "E-0002", "B+", 55000, "IT Executive", new EmployeeInfo(new EmpResidenceInfo("Vatara", "Dhaka", "01700000000"), new Date(1998, "SEP", 20), new Date(2021, "Jan", 12)), 5600);
            emp[3] = new MarketAnalyst("Rifat Karim", "E-0003", "AB+", 45000, "Market Analyst", new EmployeeInfo(new EmpResidenceInfo("Khula", "Khulna", "01800000000"), new Date(1999, "AUG", 10), new Date(2021, "Jan", 13)), 3500);
            emp[4] = new PartTimer("Nobel Khan", "E-0004", "A+", 35000, "Part Timer", new EmployeeInfo(new EmpResidenceInfo("Badda", "Dhaka", "01500000000"), new Date(2000, "JUN", 07), new Date(2021, "Jan", 14)));

            byte i = 1;
            while (i < emp.Length)
            {
                emp[i].ShowEmployeeInfo();
                Console.WriteLine();
                i++;
            }
        }
    }
}
