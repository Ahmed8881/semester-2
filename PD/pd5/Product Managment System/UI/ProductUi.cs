using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class ProductUi
    {
        public static Product GetProduct()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product MinStock: ");
            int minstock = Convert.ToInt32(Console.ReadLine());
            
            return new Product(name, category, price, stock, minstock);
        }
        public static string GetProductName()
        {
            Console.Write("Enter Product Name: ");
            return Console.ReadLine();
        }
        public static void HeaderForProduct()
        {
            Console.WriteLine("Name, Category, Price, Stock, MinStock");
        }
    }
}
