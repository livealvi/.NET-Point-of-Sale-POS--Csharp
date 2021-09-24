using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ax = new int [5] { 23, -34, 200, 334, 98 };

            for (byte q = 0; q < 5; q++)
            {
                Console.WriteLine("{0}", ax[q]);
            }

            Console.WriteLine();

            byte g = 0;

            while (g < 5)
            {
                Console.Write("{0} ", ax[g]);
                g++;
                Console.WriteLine();
            }
            Console.WriteLine();

            g = 0;
            do
            {
                Console.WriteLine("{0}", ax[g]);
                g++;
                
            } while (g < -5);

            foreach (int z in ax)
            {
                Console.WriteLine("{0}", z);
            }
            Console.WriteLine();


            int[,] bx = new int[3,4] { { 1, 2, 3, 4 }, {5, 6, 7, 8}, { 9, 10, 11, 12 } };
            int[,,,] dx = new int[2, 3, 3, 2];
            byte r = 0, c = 0;

            while (r < 3)
            {
                 c = 0;
                while (c < 4)
                {
                    Console.Write("{0} ", bx[r , c]);
                    c++;
                }
                Console.WriteLine();
                r++;
            }


            foreach (int z in bx)
            {
                Console.Write("{0} ", z);
            }

            Console.WriteLine();


        }
    }
}
