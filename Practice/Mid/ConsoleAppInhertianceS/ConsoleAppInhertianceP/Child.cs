using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInhertianceP
{
    internal class Child : Parent
    {
        internal Child() : base(45)
        {
            Console.WriteLine("Child Called");
        }

        internal Child(int e) : base()
        {
            Console.WriteLine("Child PC-I " + e);
        }
        internal Child(string t)
        {
            Console.WriteLine("Child PC-II " + t);
        }
    }
}
