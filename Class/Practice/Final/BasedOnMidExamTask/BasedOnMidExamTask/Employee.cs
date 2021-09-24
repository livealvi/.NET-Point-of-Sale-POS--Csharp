using System;
using System.Collections.Generic;
using System.Linq; 
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasedOnMidExamTask.Employees
{
    internal abstract class Employee
    {
        private static int serialNo = 0;
        protected string id;
        private string name;
        private string bloodGroup;
        private double salary;
        private string empPost;
        private EmployeeInfo employeeInfo;
        
        internal string EmpName{get; set;}
        internal virtual string EmpID
        {
            get { return this.id; }
            set { this.id = "E-" + value; }
        }
        internal string EmpBloodGroup{get; set;}
        internal double Salary
        {
            get { return this.salary; }
            set {
                if (value > 0)
                {
                    this.salary = value;
                }
                else
                {
                    this.salary = 1;
                }
            }
        }

        internal string EmployeePost{get; set;}
        internal EmployeeInfo EmployeeInfo{get; set;}

        internal virtual double TotalIncome()
        {
            return this.Salary;
        }

        internal Employee(string name, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo)
        {
            this.EmpName = name;
            this.EmpID = (++serialNo).ToString();
            this.EmpBloodGroup = bloodGroup;
            this.Salary = salary;
            this.EmployeePost = empPost;
            this.EmployeeInfo = employeeInfo;
        }

        internal virtual void ShowEmployeeInfo()
        {
            Console.WriteLine("\n\n\t-------- Show Employee Infos --------\n");
            Console.WriteLine("\tEmployee Post: {0}", this.EmployeePost);
            Console.WriteLine("\tID: {0}", this.EmpID);
            Console.WriteLine("\tName: {0}", this.EmpName);
            Console.WriteLine("\tBlood Group: {0}", this.EmpBloodGroup);
            Console.Write("\tBirth ");
            this.EmployeeInfo.BirthDate.ShowDate();
            this.EmployeeInfo.Residence.ShowEmpResidenceInfo();
            Console.Write("\tJoin ");
            this.EmployeeInfo.JoiningDate.ShowDate();
            Console.WriteLine("\tSalary : {0}", this.Salary);
            Console.WriteLine("\tTotal Income: {0}", this.TotalIncome());
        }
    }
}
