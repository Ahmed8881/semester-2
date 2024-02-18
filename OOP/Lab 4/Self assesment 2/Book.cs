using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_assessment_2
{
    internal class Book
    {

        public string title;
        public string author;
        public int pages;
        public List<string> chap;
        public int bookMarks;
        public int price;
        public bool isAvailable;

        public Book(string title,string author,int pages,List<string>chap,int bookMarks,int price,bool isAvailable) { 
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.chap = chap;
            this.bookMarks = bookMarks;
            this.price = price;
            this.isAvailable = isAvailable;

        }
        public bool isBookAvailable()
        {
            return isAvailable;
        }
        public string getChap(int chapter)
        {
            if(chapter>=0 && chapter < chap.Count)
            {
                return chap[chapter];
            }
            else
            {
                return "Invalid chapter number";
            }
        }
        public int GetBookMark()
        {
            return bookMarks;
        }

    }
}
