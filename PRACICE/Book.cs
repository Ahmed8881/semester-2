using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK4
{
    internal class Book
    {

            public string Title;
            public string Author;
            public int PublicationYear;
            public double Price;
            public int QuantityInStock;

            public Book(string title, string author, int publicationYear, double price, int quantityInStock)
            {
                Title = title;
                Author = author;
                PublicationYear = publicationYear;
                Price = price;
                QuantityInStock = quantityInStock;
            }

            public string GetTitle()
            {
                return $"Title: {Title}";
            }

            public string GetAuthor()
            {
                return $"Author: {Author}";
            }

            public string GetPublicationYear()
            {
                return $"Publication Year: {PublicationYear}";
            }

            public string GetPrice()
            {
                return $"Price: {Price}";
            }

            public void SellCopies(int numberOfCopies)
            {
                if (numberOfCopies <= QuantityInStock)
                {
                    QuantityInStock -= numberOfCopies;
                    Console.WriteLine($"{numberOfCopies} copies of {Title} sold.");
                }
                else
                {
                    Console.WriteLine($"Insufficient stock. Only {QuantityInStock} copies of {Title} available.");
                }
            }

            public void Restock(int additionalCopies)
            {
                QuantityInStock += additionalCopies;
                Console.WriteLine($"{additionalCopies} copies of {Title} added to stock.");
            }

            public string BookDetails()
            {
                return $"Title: {Title}\nAuthor: {Author}\nPublication Year: {PublicationYear}\nPrice: {Price}\nQuantity in Stock: {QuantityInStock}";
            }
        }

    }

