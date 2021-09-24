using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ConsoleAppInhertianceP
{
    internal class Student : Person
    {
        private double cgpa;

        internal double Cgpa
        {
            get {return this.cgpa;}

            set {this.cgpa = value;}
        }

        internal Student(int id, string name, string bloodGroup, double cgpa) : base(id, name, bloodGroup)
        {
            this.Cgpa = cgpa;
        }

        internal override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("CGPA: {0}", this.Cgpa);
        }
    }
}
