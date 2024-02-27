
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_3_new_PD
{
    internal class ShopCrud
    {
        public static List<CoffeeShop> CoffeeShops = new List<CoffeeShop>();
        public static void LoadShopData()
        {
            StreamReader File = new StreamReader("ShopData.csv");
            string line;
            while ((line = File.ReadLine()) != null)
            {
                List<MenuItem> menuItems = new List<MenuItem>();
                string[] data = line.Split(',');
                string[] shopItems = data[1].Split(';');
                foreach (string item in shopItems)
                {
                    MenuItem temp = MenuCrud.GetItemDetails(item);
                    if (temp != null)
                    {
                        menuItems.Add(temp);
                    }
                }
                CoffeeShop newItem = new CoffeeShop(data[0], menuItems);  // create menu object
                CoffeeShops.Add(newItem);
            }
            File.Close();
        }
        public static void AddShop(CoffeeShop Shop)
        {
            CoffeeShops.Add(Shop);
        }
        public static int GetShopIndex(string nameOfShop)
        {
            for (int i = 0; i < CoffeeShops.Count; i++)
            {
                if (nameOfShop == CoffeeShops[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }
        public static string CheapestItem(int idx)
        {
            return CoffeeShops[idx].CheapestItem();
        }
        public static string DrinkMenu(int idx)
        {
            return CoffeeShops[idx].DrinksOnly();
        }
        public static string FoodMenu(int idx)
        {
            return CoffeeShops[idx].FoodOnly();
        }
        public static bool CoffeeShopOptions(string choice)
        {
            if (choice == "3" || choice == "4" || choice == "4" || choice == "5" || choice == "6" || choice == "7" || choice == "8" || choice == "9")
                return true;
            return false;
        }
    }
}
