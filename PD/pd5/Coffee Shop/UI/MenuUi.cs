using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_3_new_PD
{
    internal class MenuUi
    {
        public static MenuItem TakeInput()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Type: ");
            string type = Console.ReadLine();

            Console.Write("Enter Price: ");
            int price = int.Parse(Console.ReadLine());

            return new MenuItem(name, type, price);
        }
    }
}
