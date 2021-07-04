using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInhertianceP
{
    internal class Parent
    {
        internal Parent()
        {
            Console.WriteLine("Parent Called");
        }
        internal Parent(int r)
        {
            Console.WriteLine("Parent PC-I " + r);
        }
    }
}
