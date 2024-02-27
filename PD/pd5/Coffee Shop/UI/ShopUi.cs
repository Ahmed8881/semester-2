using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_3_new_PD
{
    internal class ShopUi
    {
        public static string GetNameOfItem()
        {
            Console.Write("Enter name of item you want to order: ");
            return Console.ReadLine();
        }
        public static void Header()
        {
            Console.WriteLine("Orders");
        }
        public static CoffeeShop TakeInput()
        {
            Console.Write("Enter name of the shop:");
            string nameOfShop = Console.ReadLine();

            return new CoffeeShop(nameOfShop);
        }
        public static string GetNameOfShop()
        {
            Console.Write("Enter name of the shop: ");
            return Console.ReadLine();
        }
        public static void GetData()
        {
            Console.Write("Enter data: ");
            string data = Console.ReadLine();
            Console.WriteLine("Data: " + data);
        }

    }
}
