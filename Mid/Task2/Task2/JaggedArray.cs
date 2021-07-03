using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 0, y, jr = 0, jc, count1 = 1, count2 = 1;
            double total= 0, avg = 0;

            int[][] marks = new int[3][];

            marks[0] = new int[2];
            marks[1] = new int[3];
            marks[2] = new int[1];

            
            Console.WriteLine("Please Enter The Marks Between: 0 to 100");
            while (x < marks.Length)
            {
                y = 0;
                Console.WriteLine("\nFor Student {0}: ", count1++);
                while (y < marks[x].Length)
                {
                    marks[x][y] = Convert.ToInt32(Console.In.ReadLine());
                    y++;
                }
                x++;
            }

            while (jr < marks.Length)
            {
                jc = 0;
                Console.Write("\nStudent {0} Marks: ", count2++);
                total = 0;
                while (jc < marks[jr].Length)
                {
                    Console.Write("{0} || ", total += marks[jr][jc]);

                    if (marks[jr].Length > 0)
                    {
                        avg = total / marks[jr].Length;
                    }
                    jc++;
                }
                Console.Write("Total Marks: {0} || ", total);
                Console.Write("Average Mark: {0:0.00}", avg);
                Console.WriteLine();
                jr++;
                
            }

            
        }
    }
}
