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


            ITExecutive itEx = new ITExecutive();
            itEx.EmpID = "E-0001";
            itEx.EmpName = "Alvi Hasan";
            itEx.EmpBloodGroup = "B+";
            itEx.EmployeeInfo = new EmployeeInfo(new EmpResidenceInfo("Dhaka", "Khulna", "017777777"), new Date(1997, 10, 25), new Date(2021, 01, 21));
            itEx.Salary = 80000;
            itEx.Bonus = 3000;
            itEx.ShowEmpAddress();

            MarketAnalyst mA = new MarketAnalyst();
            mA.EmpID = "E-0002";
            mA.EmpName = "Hasan Mahamud";
            mA.EmpBloodGroup = "O+";
            mA.EmployeeInfo = new EmployeeInfo(new EmpResidenceInfo("Dhaka", "Jessore", "01999999999"), new Date(1999, 11, 20), new Date(2021, 08, 29));
            mA.Salary = 50000;
            mA.Commission = 7000;
            mA.ShowEmpAddress();

            HRManager hrm = new HRManager();
            hrm.EmpID = "E-0003";
            hrm.EmpName = "Rifat Karim";
            hrm.EmpBloodGroup = "O+";
            hrm.EmployeeInfo = new EmployeeInfo(new EmpResidenceInfo("Dhaka", "Bogra", "01888888888"), new Date(2000, 05, 27), new Date(2021, 02, 09));
            hrm.Salary = 75000;
            hrm.KPI = 1000;
            hrm.ShowEmpAddress();

        }
    }
}
