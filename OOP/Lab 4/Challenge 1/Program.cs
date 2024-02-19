using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[100];
            int bookCount = 0;

            bool exit = false;
            while (!exit)
            {
               
                Console.WriteLine("......Menu:................");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Search by title");
                Console.WriteLine("3. Search by ISBN");
                Console.WriteLine("4. Update stock");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Clear();
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter authors (comma-separated): ");
                    string[] authors = Console.ReadLine().Split(',');
                    Console.Write("Enter publisher: ");
                    string publisher = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();
                    Console.Write("Enter price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Enter stock: ");
                    int stock = int.Parse(Console.ReadLine());

                    Book newBook = new Book(title, authors, publisher, isbn, price, stock);
                    books[bookCount] = newBook;
                    bookCount++;
                    Console.WriteLine("Book added successfully!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (choice == 2)
                {
                    Console.Clear() ;
                    Console.Write("Enter title to search: ");
                    string searchTitle = Console.ReadLine();
                    foreach (Book book in books)
                    {
                        if (book != null)
                        {
                            book.SearchByTitle(searchTitle);
                        }
                    }
                    Console.ReadKey() ;
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    Console.Write("Enter ISBN to search: ");
                    string searchISBN = Console.ReadLine();
                    foreach (Book book in books)
                    {
                        if (book != null)
                        {
                            book.SearchByISBN(searchISBN);
                        }
                    }
                    Console.ReadKey() ;
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    Console.Write("Enter title of the book to update stock: ");
                    string updateTitle = Console.ReadLine();
                    Console.Write("Enter quantity to add: ");
                    int quantity = int.Parse(Console.ReadLine());
                    foreach (Book book in books)
                    {
                        if (book != null && book.title.ToLower() == updateTitle.ToLower())
                        {
                            book.Addcopies(quantity);
                        }
                    }
                    Console.ReadKey() ;
                }
                else if (choice == 5)
                {   
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please try again.");
                }

                Console.WriteLine();
            }
        }
    }
}
