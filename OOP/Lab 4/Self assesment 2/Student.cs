using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Self_assessment_2
{
    internal class Student
    {
        public string name;
        public int age;
        public List<Book> Books;
      
        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void DisplayBooks()
        {
            Console.WriteLine($"Books for {Name}:");
            foreach (var book in Books)
            {
                Console.WriteLine($"- {book.Title} by {book.Author}");
            }
        }
    }
}
