using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInhertianceP
{
    class Program
    {
        static void Main(string[] args)
        {

            Child c = new Child(56);
            Parent p = new Parent();
            p.MethodA();
            c.MethodA();
            p.MethodA();
            c.MethodB();

            Parent p1 = new Child();
            p1.MethodA();
            p1.MethodB();
            p1.MethodC();

            //array of objects
            /* Parent[] p = new Parent[500];
            p[0] = new Parent();
            p[1] = new Parent(46);
            p[2] = new Parent(70); */
        }
    }
}
