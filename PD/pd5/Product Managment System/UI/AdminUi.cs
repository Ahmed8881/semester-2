using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class AdminUi
    {
        public static string GetChoice()
        {
            Console.Clear();

            Console.WriteLine("Welcome Admin");

            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Find Product with Highest Unit Price");
            Console.WriteLine("4. View Sales Tax of All Products");
            Console.WriteLine("5. Products to be Ordered");
            Console.WriteLine("6. View Profile");
            Console.WriteLine("7. LogOut");

            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        public static Admin TakeAdminInput()
        {
            Console.Clear();

            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            return new Admin(userName, password);
        }
        public static void AdminHeader()
        {
            Console.WriteLine("UserName, Password");
        }

    }
}
