using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member("Ahmed", "1");
            while (true)
            {
                Console.WriteLine("1. Set Name");
                Console.WriteLine("2. Modify Name");
                Console.WriteLine("3. Buy Book");
                Console.WriteLine("4. Show Books Bought");
                Console.WriteLine("5. Show Stats");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                string choice=Console.ReadLine();
                if (choice == "1") { 
                    
                    SetName(member);
                }
                else if (choice == "2") { 
                    ModifyName(member);
                }
                else if (choice == "3") {
                    BuyBooks(member);
                }
                else if (choice == "4") {
                    member.ShowBooksBought();
                }
                else if (choice == "5") {
                    member.ShowStats();
                }
                else if (choice == "6") { }
                else
                {
                    Console.WriteLine("Invalid choice......");
                }


            }
    
        }
        static void SetName(Member member)
        {
            Console.Clear();
            Console.WriteLine("Enter your name: ");
            string name=Console.ReadLine();
            member.setName(name);
        }
        static void ModifyName(Member member)
        {
            Console.Clear();
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            member.modifyname(newName);

        }
        static void BuyBooks(Member member)
        {
            Console.Clear();
            Console.Write("Enter book name: ");
            string bookName = Console.ReadLine();
            Console.Write("Enter book price: ");
            int price = int.Parse(Console.ReadLine());
            member.BuyBook(bookName, price);
            Console.ReadKey();
        }



    
    }

}
