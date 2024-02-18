using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_assessment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test the Book and Student classes here
            Student student = new Student("John Doe", 20);

            Book book1 = new Book("Book 1", "Author 1", 200, new List<string> { "Chapter 1", "Chapter 2", "Chapter 3" }, 0, 10, true);
            Book book2 = new Book("Book 2", "Author 2", 150, new List<string> { "Chapter 1", "Chapter 2" }, 0, 15, false);

            student.AddBook(book1);
            student.AddBook(book2);

            student.DisplayBooks();
        }
    }
}
