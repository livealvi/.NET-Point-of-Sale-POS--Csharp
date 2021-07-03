using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            //StudentAddress add = new StudentAddress(2, 4, 1223, "district");
            StudentAddress add2 = new StudentAddress(33, 30, 1223, "khulna");

            Student studentOne = new Student();
            studentOne.SetId(100);
            studentOne.SetName("Bruce");
            studentOne.SetCgpa(3.45);
            studentOne.SetAddress(new StudentAddress(2, 4, 1223, "district"));
            studentOne.ShowStudentInfo();

            Student studentTwo = new Student(111, "Jon", 3.98, add2);
            studentTwo.ShowStudentInfo();

        }
    }
}
 