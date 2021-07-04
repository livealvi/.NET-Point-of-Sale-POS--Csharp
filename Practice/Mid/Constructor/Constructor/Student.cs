using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor
{

    struct StudentAddress
    {
        private byte houseNo;
        private byte roadNo;
        private ushort postalCode;
        private string district;

        public StudentAddress(byte houseNo, byte roadNo, ushort postalCode, string district)
        {
            this.houseNo = houseNo;
            this.roadNo = roadNo;
            this.postalCode = postalCode;
            this.district = district;
        }

        public void PrintAddress()
        {
            Console.WriteLine("House No: {0}", this.houseNo);
            Console.WriteLine("Road No: {0}", this.roadNo);
            Console.WriteLine("Postal Code: {0}", this.postalCode);
            Console.WriteLine("District: {0}\n", this.district);
        }
    }

    class Student
    {
        private int id;
        private string name;
        private double cgpa;
        public StudentAddress address;


        public int GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }

        public double GetCgpa()
        {
            return this.cgpa;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetCgpa(double cgpa)
        {
            if (cgpa >= 0 && cgpa <= 4.0)
            {
                this.cgpa = cgpa;
            }
            else
            {
                this.cgpa = -1;
            }
        }

        public StudentAddress GetAddress()
        {
            return this.address;
        }

        public void SetAddress(StudentAddress address)
        {
            this.address = address;
        }

        public Student()
        {

        }

        public Student(int id, string name, double cgpa, StudentAddress address)
        {
            this.SetId(id);
            this.SetName(name);
            this.SetCgpa(cgpa);
            this.SetAddress(address);
        }

        public void ShowStudentInfo()
        {
            Console.WriteLine("Student Id: {0}", this.GetId());
            Console.WriteLine("Student Name: {0}", this.GetName());
            Console.WriteLine("Student CGPA: {0}", this.GetCgpa());
            this.address.PrintAddress();
        }

    }
}
