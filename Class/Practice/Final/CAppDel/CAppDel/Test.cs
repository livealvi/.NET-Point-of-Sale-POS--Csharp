using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAppDel
{

    public delegate void DelegateSample(int r);


    internal class Test
    {

        public delegate int DelSample(int a, int b);

        public void Add(int x)
        {
            Console.WriteLine(x + 10);
        }

        public void Sub(int x)
        {
            Console.WriteLine(x - 10);
        }

        public int M2(int a, int b)
        {
        }
    }

}
