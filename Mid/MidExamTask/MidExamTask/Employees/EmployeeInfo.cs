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
        private byte month;
        private ushort year;


        public Date(ushort year, byte month, byte day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public void ShowDate()
        {
            Console.WriteLine("Date: {0}/{1}/{2}", year, month, day);
        }
    }

    struct EmpResidenceInfo 
    {
        private string thana;
        private string homeDistrict;
        private string phoneNo;

        public EmpResidenceInfo(string thana, string homeDistrict, string phoneNo)
        {
            this.thana = thana;
            this.homeDistrict = homeDistrict;
            this.phoneNo = phoneNo;
        }
        public void ShowEmpResidenceInfo()
        {
            Console.WriteLine("Thana: {0}", thana);
            Console.WriteLine("Home District: {0}", homeDistrict);
            Console.WriteLine("Phone: {0}", phoneNo);
        }
    }
    class EmployeeInfo
    {
        private Date birthDate;
        private Date joiningDate;
        private EmpResidenceInfo addressInfo;

        public EmployeeInfo()
        {

        }
        public EmployeeInfo(EmpResidenceInfo addressInfo, Date birthDate, Date joiningDate)
        {
            this.Residence = addressInfo;
            this.BirthDate = birthDate;
            this.JoiningDate = joiningDate;
        }
        public EmpResidenceInfo Residence
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
