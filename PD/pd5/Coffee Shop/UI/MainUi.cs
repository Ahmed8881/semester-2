using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_3_new_PD
{
    internal class MainUi
    {
        public static string MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.Add a Menu item");
            Console.WriteLine("2.Add a Coffee Shop");
            Console.WriteLine("3.View the Cheapest Item in the menu from a specific coffee shop");
            Console.WriteLine("4.View the Drink’s Menu from a specific coffee shop");
            Console.WriteLine("5.View the Food’s Menu from a specific coffee shop");
            Console.WriteLine("6.Add Order in a specific coffee shop");
            Console.WriteLine("7.Fulfill the Order in a specific coffee shop");
            Console.WriteLine("8.View the Orders’s List from a specific coffee shop");
            Console.WriteLine("9.Total Payable Amount from a specific coffee shop");
            Console.WriteLine("10.Exit");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("Enter Choice: ");
            return Console.ReadLine();
        }
    }
}
