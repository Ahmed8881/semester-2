using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    internal class Member
    {
        public Member(string name,string memberId) { 
            this.name = name;
            this.memberId = memberId;
            books = new List<string>();

        }
        public string name;
        public string memberId;
        public List<string> books;
        public int bookbought;
        public float moneyInBank;
        public float amountSpent;
        public string showName()
        {
            return name;
        }
        public string modifyname(string newName)
        {
            name = newName;
            return name;
        }
        public string setName(string addname)
        {
            name=addname;
            return name;
        }
        public void ShowStats()
        {
            Console.WriteLine("Member ID: " + memberId);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Number of Books Bought: " + bookbought);
            Console.WriteLine("Amount Spent: " + amountSpent);
        }
        public void BuyBook(string bookName, int price)
        {
            Console.WriteLine("Buying book: " + bookName);
            books.Add(bookName);
            bookbought++;
            moneyInBank -= price;
            amountSpent += price;
        }
        public void ShowBooksBought()
        {
            Console.WriteLine("Books Bought:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i]);
            }
        }



    }

}
