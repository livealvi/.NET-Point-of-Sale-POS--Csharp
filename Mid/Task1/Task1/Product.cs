using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    struct ManufactureDate
    {
        private byte date;
        private byte month;
        private ushort year;

        public ManufactureDate(byte date, byte month, ushort year)
        {
            this.date = date;
            this.month = month;
            this.year = year;
        }
        public void ShowManufactureDate()
        {
            Console.WriteLine("Product's Date: {0}/{1}/{2}", date, month, year);
        }
    }

    class Product
    {
        private string id;
        private double price;
        private ManufactureDate productManufactureDate;

        public Product()
        {
            //default constructor
        }

        public Product(string id, double price, ManufactureDate productManufactureDate)
        {
            this.ProductId = id;
            this.ProductPrice = price;
            this.ProductDate = productManufactureDate;
        }

        public string ProductId
        {
            get {return this.id;}
            set { this.id = value;}
        }

        public double ProductPrice
        {
            get {return this.price;}
            set {this.price = value;}
        }

        public ManufactureDate ProductDate
        {
            get { return this.productManufactureDate; }
            set { this.productManufactureDate = value; }
        }


        public void ShowProductInfo()
        {
            Console.WriteLine("Product's ID: {0}", this.ProductId);
            Console.WriteLine("Product's Price: {0}", this.ProductPrice);
            this.ProductDate.ShowManufactureDate();
            Console.WriteLine();
        }
    }
}
