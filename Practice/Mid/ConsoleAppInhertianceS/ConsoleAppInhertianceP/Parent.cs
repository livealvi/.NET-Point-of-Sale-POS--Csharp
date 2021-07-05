using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInhertianceP
{
    internal class Parent
    {
        internal Parent() : this("TEST")
        {
            Console.WriteLine("Parent Called");
        }
        internal Parent(int r) //: this()
        {
            Console.WriteLine("Parent PC-I " + r);
        }
        internal Parent(String s)
        {
            Console.WriteLine("Parent PC-S " + s);
        }
        internal virtual void MethodA()
        {
            Console.WriteLine("Parent MethodA");
        }
        internal void MethodB()
        {
            Console.WriteLine("Parent MethodB");
        }
        internal virtual void MethodC()
        {
            Console.WriteLine("Parent MethodC");
        }
    }
}
