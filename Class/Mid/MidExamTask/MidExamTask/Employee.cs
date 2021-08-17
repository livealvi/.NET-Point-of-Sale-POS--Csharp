using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MidExamTask.Employees;

namespace MidExamTask.Employees
{
    internal class Employee
    {
        private string id;
        private string name;
        private string bloodGroup;
        private double salary;
        private string empPost;
        private EmployeeInfo employeeInfo;
        
        internal string EmpName
        {
            get { return this.name; }

            set { this.name = value; }
        }
        internal string EmpID
        {
            get { return this.id; }

            set { this.id = value; }
        }
        internal string EmpBloodGroup
        {
            get { return this.bloodGroup; }

            set { this.bloodGroup = value; }
        }
        internal double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        internal string EmployeePost
        {
            get {return this.empPost;}

            set {this.empPost = value;}
        }
        internal EmployeeInfo EmployeeInfo
        {
            get { return this.employeeInfo; }
            set { this.employeeInfo = value; }
        }

        internal Employee(string name, string id, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo)
        {
            this.EmpName = name;
            this.EmpID = id;
            this.EmpBloodGroup = bloodGroup;
            this.Salary = salary;
            this.EmployeePost = empPost;
            this.EmployeeInfo = employeeInfo;
        }

        internal virtual void ShowEmployeeInfo()
        {
            Console.WriteLine("\n\n\t-------- Show Employee Infos --------\n");
            Console.WriteLine("\tEmployee Post:{0}", this.EmployeePost);
            Console.WriteLine("\tID: {0}", this.EmpID);
            Console.WriteLine("\tName: {0}", this.EmpName);
            Console.WriteLine("\tBlood Group: {0}", this.EmpBloodGroup);
            Console.Write("\tBirth ");
            this.EmployeeInfo.BirthDate.ShowDate();
            this.EmployeeInfo.Residence.ShowEmpResidenceInfo();
            Console.WriteLine("\tSalary : {0}", this.Salary);
            Console.Write("\tJoin ");
            this.EmployeeInfo.JoiningDate.ShowDate();
        }

    }
}
