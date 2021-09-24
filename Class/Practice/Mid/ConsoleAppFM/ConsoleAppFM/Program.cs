using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFM
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.p = 50;
            int h = Test.q;
            int i = t.r;

            Console.WriteLine("{0}, {1}, {2}", Days.Saturday, Days.Monday, Days.Sunday);
            int g = (int)Days.Sunday;
            Console.WriteLine("{0} ", g);

            int[] ax = new int[5] { 1, 2, 3, 4, 5 };
            int[] bx = new int [6] { 6,7,8,9,10,11 };

            t.Addition(ax);
        }
    }
}
