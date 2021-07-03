using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurePractice
{
    struct TextBook
    {
        public int ISBN , totalPages , month, year;
        public string bookName , authorName;
        public double price;

        public void showBookInfo()
        {
            Console.WriteLine("ISBN: {0}  ||  Book Name: {1}  ||  Total Pages: {2}  ||  Author: {3}  ||  Price: {4}  ||  Publication Date: {5}/{6}", ISBN , bookName , totalPages , authorName , (double)price, month, year);
        }

        class Program
        {
            static void Main(string[] args)
            {
                TextBook book1;
                book1.ISBN = 1122334456;
                book1.bookName = "Learn C#";
                book1.totalPages = 4590;
                book1.authorName = "Alvi Hasan";
                book1.price = 1250.51;
                book1.month = 06;
                book1.year = 2021;
                book1.showBookInfo();
            }
        }
    }
}
