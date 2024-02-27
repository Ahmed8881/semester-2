using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_3_new_PD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuCrud.LoadMenuItems();
            ShopCrud.LoadShopData();

            string choice;
            while (true)
            {
                choice = MainUi.MainMenu();

                Console.Clear();

                if (choice == "1")
                {
                    MenuItem Item = MenuUi.TakeInput();
                    MenuCrud.AddItem(Item);
                }
                else if (choice == "2")
                {
                    CoffeeShop Shop = ShopUi.TakeInput();
                    ShopCrud.AddShop(Shop);
                }
                else if (ShopCrud.CoffeeShopOptions(choice))   // for all choice of 3 to 9 this code will execute
                {
                    string name = ShopUi.GetNameOfShop();
                    int index = ShopCrud.GetShopIndex(name);
                    if (index == -1)
                    {
                        Console.WriteLine("Invalid Shop Name...");
                    }
                    else
                    {
                        if (choice == "3")
                        {
                            string msg = ShopCrud.CheapestItem(index);
                            Console.WriteLine(msg);
                        }
                        else if (choice == "4")
                        {
                            string msg = ShopCrud.DrinkMenu(index);
                            Console.WriteLine(msg);
                        }
                        else if (choice == "5")
                        {
                            string msg = ShopCrud.FoodMenu(index);
                            Console.WriteLine(msg);
                        }
                        else if (choice == "6")
                        {
                            ShopCrud.CoffeeShops[index].AddOrder();
                        }
                        else if (choice == "7")
                        {
                            ShopCrud.CoffeeShops[index].FulfillOrder();
                        }
                        else if (choice == "8")
                        {
                            string listOfOrders = ShopCrud.CoffeeShops[index].ListOrders();
                            Console.WriteLine(listOfOrders);
                        }
                        else if (choice == "9")
                        {
                            int payableAmount = ShopCrud.CoffeeShops[index].DueAmount();
                            Console.WriteLine($"Total Payable Amount is: {payableAmount}");
                        }
                    }
                }
                else if (choice == "10")
                {
                    return; // end
                }
                Console.Write("Press Any Key....");
                Console.ReadKey();
            }
        }
    }
}
