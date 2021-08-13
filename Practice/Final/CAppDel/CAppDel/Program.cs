using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAppDel
{

    internal class Employee
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            //GenericClass<int> g1 = new GenericClass<int>();
            //g1.rx[1] = 8;
            //GenericClass<string> g2 = new GenericClass<string>();
            //g2.Ax = "edf";
            //GenericClass<Employee> g3 = new GenericClass<Employee>();
            //g3.Ax = new Employee();

            //List<int> intList = new List<int>();
            //intList.Add(24);
            //intList.Add(56);
            //intList.Add(-90);
            //intList.Add(5);
            //intList.Add(35);

            //Console.WriteLine("Count: {0}", intList.Count + "\n");

            //foreach (int item in intList) 
            //    Console.WriteLine("Items: {0}",item);
            //Console.WriteLine("\nElement: {0}",intList[1]);

            Test t1 = new Test();
            DelegateSample dsl = new DelegateSample(t1.Add);
            dsl(50);
            DelegateSample dsl2 = t1.Sub;
            dsl2(35);

            DelegateSample ds = dsl + dsl2;
            ds(30);

            Test.DelSample ddl = t1.M2;
            ddl(34, 345);

        }
    }
}
