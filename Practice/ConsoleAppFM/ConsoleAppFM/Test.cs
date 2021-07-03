using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFM
{

    enum Days
    {
        Saturday = 100, 
        Sunday = 200,
        Monday
    }

    class Test
    {
        public int p = 10;
        public const int q = 20;
        public readonly int r = 30;
        public Test()
        {
            p = 88;
            //q = 12;
            r = 77;
            r = 88;
        }

        public void Addition(int[] sum)
        {
            int result = 0;
            int index = 0;
            while (index < sum.Length)
            {
                result += sum[index];
                index++;
            }

            Console.WriteLine("\nSum : {0}" ,result);
        }
    }
}
