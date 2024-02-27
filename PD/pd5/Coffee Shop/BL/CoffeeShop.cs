using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlng_3_new_PD
{
    internal class CoffeeShop
    {
        public string Name;
        public List<string> Orders;
        public List<MenuItem> MenuItems;
        public CoffeeShop(string name)
        {
            Name = name;
            Orders = new List<string>();
            MenuItems = new List<MenuItem>();
        }
        public CoffeeShop(string name, List<MenuItem> menuItems)
        {
            Name = name;
            Orders = new List<string>();
            MenuItems = menuItems;
        }
        public void AddMenuItem()
        {
            MenuItem NewItem = MenuUi.TakeInput();
            MenuItems.Add(NewItem);
        }
        public void AddOrder()
        {
            string nameOfItem = ShopUi.GetNameOfItem();
            if (ItemExist(nameOfItem))
            {
                Orders.Add(nameOfItem);
                Console.WriteLine("Order Added Successfully");
            }
            else
            {
                Console.WriteLine("Item does not exist");
            }
        }
        private bool ItemExist(string name)
        {
            foreach (MenuItem item in MenuItems)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void FulfillOrder()
        {
            if (Orders != null)
            {
                for (int i = 0; i < Orders.Count(); ++i)
                {
                    Console.WriteLine($"The \"{Orders[i]}\" is Ready!");
                    Orders.Remove(Orders[i]);
                }
            }
            else
            {
                Console.WriteLine("No items ordered");
            }
        }

        public string ListOrders()
        {
            string msg = "";

            ShopUi.Header();

            if (Orders != null)
            {
                foreach (string order in Orders)
                {
                    msg += order;
                    msg += "\n";  // formatting
                }
            }
            else
            {
                msg = "No items ordered";
            }

            return msg;
        }
        public int DueAmount()
        {
            int totalAmount = 0;
            foreach (MenuItem M in MenuItems)
            {
                foreach (string order in Orders)
                {
                    if (M.Name == order)
                    {
                        totalAmount += M.Price;
                    }
                }
            }
            return totalAmount;
        }
        public string CheapestItem()
        {
            List<MenuItem> SortedItem = MenuItems.OrderBy(x => x.Price).ToList();
            string cheapestItem = SortedItem[0].Name;

            return $"Cheapest item available in Menu is {cheapestItem}";
        }
        public string DrinksOnly()
        {
            string msg = "All Avaiable Drinks\n\n";  // header
            foreach (MenuItem item in MenuItems)
            {
                if (item.Type == "Drink")
                {
                    msg += item.Name;
                    msg += "\n";  // formatting
                }
            }
            return msg;
        }
        public string FoodOnly()
        {
            string msg = "All Avaiable Food Items\n\n";  // header
            foreach (MenuItem item in MenuItems)
            {
                if (item.Type == "Food")
                {
                    msg += item.Name;
                    msg += "\n";  // formatting
                }
            }
            return msg;
        }
    }
}
