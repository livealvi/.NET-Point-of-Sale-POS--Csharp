using System;
using System.Data;

namespace Structure
{
    //struct Point
    //{
    //    public int x, y;

    //    public void PrintPoint()
    //    {
    //        Console.WriteLine("({0},{1})", x, y);
    //    }
    //}

    struct OurAddress
    {
        //public byte houseNo;
        //public byte roadNo;
        //public ushort postalCode;
        //public string district;

        private byte houseNo;
        private byte roadNo;
        private ushort postalCode;
        private string district;

        public OurAddress(byte houseNo, byte roadNo, ushort postalCode, string district)
        {
            this.houseNo = houseNo;
            this.roadNo = roadNo;
            this.postalCode = postalCode;
            this.district = district;
        }

        public void PrintAdrress()
        {
            Console.WriteLine("House NO: {0}", this.houseNo);
            Console.WriteLine("Road NO: {0}", this.roadNo);
            Console.WriteLine("Postal Code: {0}", this.postalCode);
            Console.WriteLine("District: {0}", this.district);
            Console.WriteLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Point p1;
            //p1.x = 5;
            //p1.y = 3;
            //p1.PrintPoint();

            //Point p2;
            //Console.Write("Enter first number: ");
            //p2.x = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter second number: ");
            //p2.y = Convert.ToInt32(Console.ReadLine());
            //p2.PrintPoint();


            //OurAddress a1;
            //a1.houseNo = 45;
            //a1.roadNo = 10;
            //a1.postalCode = 1210;
            //a1.district = "Khulna";
            //a1.PrintAdrress();

            //OurAddress a2;
            //a2.houseNo = 30;
            //a2.roadNo = 11;
            //a2.postalCode = 1200;
            //a2.district = "Bogra";
            //a2.PrintAdrress();

            OurAddress a3 = new OurAddress(33, 100, 1221, "Sylhet");
            a3.PrintAdrress();

        }
    }
}
