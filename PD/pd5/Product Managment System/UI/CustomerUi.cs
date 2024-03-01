using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class CustomerUi
    {
        public static string GetChoice()
        {
            Console.Clear();

            Console.WriteLine("Welcome Customer");

            Console.WriteLine("1. View all the products");
            Console.WriteLine("2. Buy Product");
            Console.WriteLine("3. Generate Invoice");
            Console.WriteLine("4. View Profile");
            Console.WriteLine("5. Log-Out");

            Console.Write("Enter Choice: ");
            return Console.ReadLine();
        }
        
        public static Customer TakeCustomerInput()
        {
            Console.Clear();

            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Contact: ");
            string contact = Console.ReadLine();

            return new Customer(userName, password, email, address, contact);
        }
        public static void CustomerHeader()
        {
            Console.WriteLine("UserName, Password, Email, Address, Contact");
        }
    }
}
