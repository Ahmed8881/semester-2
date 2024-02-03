using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All the Books information");
                Console.WriteLine("3. Get the Author details of a specific book");
                Console.WriteLine("4. Sell Copies of a Specific Book");
                Console.WriteLine("5. Restock a Specific Book");
                Console.WriteLine("6. See the count of the Books present in your bookList");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter the title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter the author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter the publication year: ");
                    int publicationYear = int.Parse(Console.ReadLine());
                    Console.Write("Enter the price: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the quantity in stock: ");
                    int quantityInStock = int.Parse(Console.ReadLine());

                    Book newBook = new Book(title, author, publicationYear, price, quantityInStock);
                    bookList.Add(newBook);
                    Console.WriteLine("Book added successfully.");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Book Information:");
                    foreach (Book book in bookList)
                    {
                        Console.WriteLine(book.BookDetails());
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter the title of the book: ");
                    string searchTitle = Console.ReadLine();
                    bool found = false;

                    foreach (Book book in bookList)
                    {
                        if (book.Title.Contains(searchTitle))
                        {
                            Console.WriteLine(book.GetAuthor());
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter the title of the book: ");
                    string sellTitle = Console.ReadLine();
                    bool foundBook = false;

                    foreach (Book book in bookList)
                    {
                        if (book.Title.Contains(sellTitle))
                        {
                            Console.Write("Enter the number of copies to sell: ");
                            int numberOfCopies = int.Parse(Console.ReadLine());
                            book.SellCopies(numberOfCopies);
                            foundBook = true;
                            break;
                        }
                    }

                    if (!foundBook)
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("Enter the title of the book: ");
                    string restockTitle = Console.ReadLine();
                    bool foundBookToRestock = false;

                    foreach (Book book in bookList)
                    {
                        if (book.Title.Contains(restockTitle))
                        {
                            Console.Write("Enter the number of copies to restock: ");
                            int additionalCopies = int.Parse(Console.ReadLine());
                            book.Restock(additionalCopies);
                            foundBookToRestock = true;
                            break;
                        }
                    }

                    if (!foundBookToRestock)
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine($"Number of books in the list: {bookList.Count}");
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Exiting the program...");
                    return;
                }
                else 
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }
    }
}
