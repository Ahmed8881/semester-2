using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    internal class Book
    {
        public string title;
        public string[] authors;
        public string publisher;
        public string isbn;
        public double price;
        public int stock;
       
        public Book(string title, string[]authors, string publisher, string isbn, double price, int stock)
        {
            this.title = title;
            this.authors =authors;
            this.publisher = publisher;
            this.isbn = isbn;
            this.price = price;
            this.stock = stock;
        }
        public void showTitle()
        {
            Console.WriteLine("TITLE: "+title);
        }
        public void showAuthor()
        {
            Console.WriteLine("Authors" + string.Join(";", authors));
        }
        public void showPublisher()
        {
            Console.WriteLine("PUBLISHER:"+publisher);
        }
        public void ShowISBN()
        {
            Console.WriteLine("ISBN: " + isbn);
        }
        public void ShowPrice()
        {
            Console.WriteLine("Price: $" + price);
        }

        public void ShowStock()
        {
            Console.WriteLine("Stock: " + stock);
        }
        public void Addcopies(int value)
        {
            stock += value;
            Console.WriteLine(value + " are now added to the stock...");

        }
        public void SearchByTitle(string searchTitle)
        {
            if (title.ToLower() == searchTitle.ToLower())
            {
                Console.WriteLine("Book found!");
                ShowDetails();
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        public void SearchByISBN(string searchISBN)
        {
            if (isbn == searchISBN)
            {
                Console.WriteLine("Book found!");
                ShowDetails();
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        public void ShowDetails()
        {
            Console.WriteLine("Book Details:");
            showTitle();
            showAuthor();
            showPublisher();
            ShowISBN();
            ShowPrice();
            ShowStock();
        }

    }
}
