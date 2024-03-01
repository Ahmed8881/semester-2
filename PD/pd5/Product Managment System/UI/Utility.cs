using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class Utility
    {
        public static string MainMenu()
        {
            Console.Clear();

            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Exit");

            Console.Write("Enter Choice: ");
            return Console.ReadLine();
        }
        public static string SignAsMenu(string type)
        {
            // type will have "in" or "up"
            type = type.ToLower();
            
            Console.Clear();
            
            Console.WriteLine($"1. Sign-{type} as Admin");
            Console.WriteLine($"2. Sign-{type} as Customer");
            Console.WriteLine("3. Go Back");

            Console.Write("Enter Choice: ");
            return Console.ReadLine();
        }
        public static string GetName()
        {   
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine();

            return userName;
        }
        public static string GetPassword()
        {
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            
            return password;
        }
        public static void DisplayError(string msg) 
        {
            Console.WriteLine(msg);
            PressAnyKey();
        }
        public static void PressAnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
