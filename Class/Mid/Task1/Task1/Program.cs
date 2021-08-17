using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {

            Product productOne = new Product();
            productOne.ProductId = "p-001";
            productOne.ProductPrice = 200.55;
            productOne.ProductDate = new ManufactureDate(20, 06, 2021);
            productOne.ShowProductInfo();

            Product productTwo = new Product();
            productTwo.ProductId = "p-002";
            productTwo.ProductPrice = 159.44;
            productTwo.ProductDate = new ManufactureDate(21, 05, 2021);
            productTwo.ShowProductInfo();

        }
    }
}
