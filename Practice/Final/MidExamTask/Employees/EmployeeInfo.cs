using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidExamTask.Employees
{
    struct Date
    {
        private byte day;
        private string month;
        private ushort year;
        internal Date(ushort year, string month, byte day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        internal void ShowDate()
        {
            Console.WriteLine("Date: {0}/{1}/{2}", year, month, day);
        }
    }

    struct EmpResidenceInfo 
    {
        private string thana;
        private string homeDistrict;
        private string phoneNo;
        internal EmpResidenceInfo(string thana, string homeDistrict, string phoneNo)
        {
            this.thana = thana;
            this.homeDistrict = homeDistrict;
            this.phoneNo = phoneNo;
        }
        internal void ShowEmpResidenceInfo()
        {
            Console.WriteLine("\tThana: {0}", thana);
            Console.WriteLine("\tHome District: {0}", homeDistrict);
            Console.WriteLine("\tPhone: {0}", phoneNo);
        }
    }
    internal class EmployeeInfo
    {
        private Date birthDate;
        private Date joiningDate;
        private EmpResidenceInfo addressInfo;

        internal EmployeeInfo(EmpResidenceInfo addressInfo, Date birthDate, Date joiningDate)
        {
            this.Residence = addressInfo;
            this.BirthDate = birthDate;
            this.JoiningDate = joiningDate;
        }
        internal EmpResidenceInfo Residence
        {
            get { return this.addressInfo; }

            set { this.addressInfo = value; }
        }

        internal Date BirthDate
        {
            get {return this.birthDate;}

            set {this.birthDate = value;}
        }

        internal Date JoiningDate
        {
            get { return this.joiningDate; }

            set { this.joiningDate = value; }
        }

    }
}
