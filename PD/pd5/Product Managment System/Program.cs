using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class Program
    {
        public static string productsDataPath = "productsData.csv";

        public static bool AdminLogin;
        public static bool CustomerLogin;
        public static int index;       // index of user who log in
        static void Main(string[] args)
        {
            ProductCrud.LoadProductsFrom(productsDataPath);
        Logout:  // user logs out
            
            // vals reset
            string mainChoice = "";
            string signChoice = "";
            AdminLogin = false;
            CustomerLogin = false;
            index = -1;

            while (true)
            {
                mainChoice = Utility.MainMenu();
                if (mainChoice == "1")
                {
                    while (true)
                    {
                        signChoice = Utility.SignAsMenu("in");
                        Console.Clear();
                        if (signChoice == "1")
                        {
                            bool flag = UtilCrud.Validate("admin");
                            if (flag)
                            {
                                AdminLogin = true;
                                break;
                            }
                            else
                            {
                                Utility.DisplayError("invalid pass or name");
                            }
                        }
                        else if (signChoice == "2")
                        {
                            bool flag = UtilCrud.Validate("customer");
                            if (flag)
                            {
                                CustomerLogin = true;
                                break;
                            }
                            else
                            {
                                Utility.DisplayError("invalid pass or name");
                            }
                        }
                        else if (signChoice == "3")
                        {
                            break;
                        }
                        Utility.PressAnyKey();
                    }   
                }
                else if (mainChoice == "2")
                {
                    while(true)
                    {
                        signChoice = Utility.SignAsMenu("up");
                        if (signChoice == "1")
                        {
                            Admin newAdmin = AdminUi.TakeAdminInput();
                            AdminCrud.AddAdmin(newAdmin);
                        }
                        else if (signChoice == "2")
                        {
                            Customer newCustomer = CustomerUi.TakeCustomerInput();
                            CustomerCrud.AddCustomer(newCustomer);
                        }
                        else if (signChoice == "3")
                        {
                            break;
                        }
                        Utility.PressAnyKey();
                    }
                }
                else if (mainChoice == "3")
                {
                    ProductCrud.StoreProductsTo(productsDataPath);
                    return;
                }
                if (AdminLogin || CustomerLogin)
                {
                    break;
                }
                Utility.PressAnyKey();
            }
            // users are logged in
            string userChoice = "";
            if (AdminLogin)
            {
                while (true)
                {
                    userChoice = AdminUi.GetChoice();
                    
                    Console.Clear();
                    
                    if (userChoice == "1")
                    {
                        Product Prod = ProductUi.GetProduct();
                        ProductCrud.AddProduct(Prod);
                    }
                    else if (userChoice == "2")
                    {
                        ProductCrud.ViewProducts();
                    }
                    else if (userChoice == "3")
                    {
                        ProductUi.HeaderForProduct();
                        string msg = ProductCrud.FindProductWithHighPrice();
                        Console.WriteLine(msg);
                    }
                    else if (userChoice == "4")
                    {
                        int totalTax = ProductCrud.ViewSalesTax();
                        Console.WriteLine($"Total Sales Tax: {totalTax}%");
                    }
                    else if (userChoice == "5")
                    {
                        ProductUi.HeaderForProduct();
                        string prodToOrder = ProductCrud.ViewProductsToBeReordered();
                        Console.Write(prodToOrder);
                    }
                    else if (userChoice == "6")
                    {
                        AdminUi.AdminHeader();
                        string msg = AdminCrud.ViewCredentials();
                        Console.WriteLine(msg);
                    }
                    else if (userChoice == "7")
                    {
                        goto Logout;
                    }
                    Utility.PressAnyKey();
                }
            }
            else if (CustomerLogin)
            {
                while (true)
                {
                    userChoice = CustomerUi.GetChoice();

                    Console.Clear();

                    if (userChoice == "1")
                    {
                        ProductCrud.ViewProducts();
                    }
                    else if (userChoice == "2")
                    {
                        CustomerCrud.BuyProduct();
                    }
                    else if (userChoice == "3")
                    {
                        string invoice = CustomerCrud.GenerateInvoice();
                        Console.WriteLine(invoice);
                    }
                    else if (userChoice == "4")
                    {
                        CustomerUi.CustomerHeader();
                        string msg = CustomerCrud.ViewCredentials();
                        Console.WriteLine(msg);
                    }
                    else if (userChoice == "5")
                    {
                        goto Logout;
                    }
                    Utility.PressAnyKey();
                }
            }
        }
    }
}
