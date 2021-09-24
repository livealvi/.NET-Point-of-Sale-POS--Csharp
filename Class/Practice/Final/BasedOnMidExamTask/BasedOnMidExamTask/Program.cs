using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasedOnMidExamTask.Employees;

namespace BasedOnMidExamTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n======= Welcome to Employees Management System =======\n");
            
            int w;
            
            XYZCompany.AddEmployee(new HRManager("Alvi Hasan", "B+", 75000, "HR Manager", new EmployeeInfo(new EmpResidenceInfo("Kowtali", "Jessore", "01900000000"), new Date(1997, "OCT", 25), new Date(2021, "Jan", 11)), 5000));
            XYZCompany.AddEmployee(new ITExecutive("Hasan Mahamud", "B+", 55000, "IT Executive", new EmployeeInfo(new EmpResidenceInfo("Vatara", "Dhaka", "01700000000"), new Date(1998, "SEP", 20), new Date(2021, "Jan", 12)), 4500));
            XYZCompany.AddEmployee(new MarketAnalyst("Rifat Karim", "AB+", 45000, "Market Analyst", new EmployeeInfo(new EmpResidenceInfo("Khulna", "Khulna", "01800000000"), new Date(1999, "AUG", 10), new Date(2021, "Jan", 13)), 3500));
            XYZCompany.AddEmployee(new PartTimer("Nobel Khan", "A+", 35000, "Part Timer", new EmployeeInfo(new EmpResidenceInfo("Badda", "Dhaka", "01500000000"), new Date(2000, "JUN", 07), new Date(2021, "Jan", 14))));
            XYZCompany.ShowAll();
            //XYZCompany.Search("E-1-HRM", out w);
            //XYZCompany.DeleteEmployee("E-1-HRM");

            //CTS - Common Type System
            Object o1 = 23;
            Object o2 = 34.554;
            Object o3 = new EmpResidenceInfo();

            var a = 23;
            var b = 56.0987;
            var c = new int[67];

            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());
            Console.WriteLine(c.GetType());

            dynamic u = 56;
            dynamic v = new XYZCompany();

            Nullable<int> q = null;
            int? e = null;
            int n = e ?? -1;
        }
    }
}
