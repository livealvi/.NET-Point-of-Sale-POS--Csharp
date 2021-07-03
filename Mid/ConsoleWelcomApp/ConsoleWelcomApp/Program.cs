using System;

namespace ConsoleWelcomApp
{
    class Program
    {
        class A
        {
            double r = 12;
            public A() { this.r++; Console.Write("{0} ", r); }
            public A(int y) { this.r += (y++); Console.Write("{0}", r); }
        }
        class B
        {
            public static void Main(String[] args)
            {
                A a1 = new A();
                new A(20);
            }
        }
    }
}
