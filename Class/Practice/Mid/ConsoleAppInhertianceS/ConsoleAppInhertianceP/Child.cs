using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInhertianceP
{
    internal class Child : Parent
    {
        internal Child() : base("OK")
        {
            Console.WriteLine("Child Called");
        }

        internal Child(int e) : base(e)
        {
            Console.WriteLine("Child PC-I " + e);
        }
        internal Child(string t) 
        {
            Console.WriteLine("Child PC-S " + t);
        }
        internal override void MethodA()
        {
            Console.WriteLine("Child MethodA");
        }
        internal void MethodB()
        {
            Console.WriteLine("Child MethodB");
        }
        internal void MethodC()
        {
            Console.WriteLine("Child MethodC");
        }
    }
}
