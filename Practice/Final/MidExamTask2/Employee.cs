using System;
using System.Collections.Generic;
using System.Linq; 
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    internal class Employee
    {
        private static int serialNo = 0;
        protected string id;
        private string name;
        private string bloodGroup;
        private double salary;
        private string empPost;
        private EmployeeInfo employeeInfo;

        internal string EmpName{get; set;}

        internal virtual string EmpId
        {
            get { return this.id; }

            set
            {
                this.id = "E-" + value ;
            }
        }
        internal string EmpBloodGroup{get; set;}

        internal double Salary
        {
            get { return this.salary; }

            set
            {  
                if(value > 0 )
                    this.salary = value;
                else
                {
                    this.salary = 1;
                }
            }
        }

        internal string EmployeePost{get; set;}
        
        internal EmployeeInfo EmployeeInfo { get; set; }
        
        internal Employee(string name, string bloodGroup, double salary, string empPost, EmployeeInfo employeeInfo)
        {
            this.EmpName = name;
            this.EmpId = (serialNo++).ToString();
            this.EmpBloodGroup = bloodGroup;
            this.Salary = salary;
            this.EmployeePost = empPost;
            this.EmployeeInfo = employeeInfo;
        }

        internal virtual void ShowEmployeeInfo()
        {
            Console.WriteLine("\n\n\t-------- Show Employee Infos --------\n");
            Console.WriteLine("\tEmployee Post:{0}", this.EmployeePost);
            Console.WriteLine("\tID: {0}", this.EmpId);
            Console.WriteLine("\tName: {0}", this.EmpName);
            Console.WriteLine("\tBlood Group: {0}", this.EmpBloodGroup);
            Console.Write("\tBirth ");
            this.EmployeeInfo.BirthDate.ShowDate();
            this.EmployeeInfo.Residence.ShowEmpResidenceInfo();
            Console.WriteLine("\tSalary : {0}", this.Salary);
            Console.Write("\tJoin ");
            this.EmployeeInfo.JoiningDate.ShowDate();
        }

        //internal abstract void M1();

    }
}
