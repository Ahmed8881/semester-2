using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author A = new Author("Ali","Emial","Male");
            Book book = new Book("HarryPater","Ali","Email","Male",A);
            Console.WriteLine(book.GetBookName()+A.GetName()+A.GetEmail());
            Console.ReadLine();
        }
    }
}

