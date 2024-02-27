using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Book
    {
        private string BookName;
        public string GetBookName()
        {
            return BookName;
        }
        public void SetBookName(string BookName)
        {
            this.BookName = BookName;
        }
        private Author Authors;
        public Book(string BookName, string Name, string Email, string Gender, Author Authors)
        {
            this.BookName = BookName;
            this.Authors=new Author(Authors.GetName(),Authors.GetEmail(),Authors.GetGender());
            
        }
    }
}
