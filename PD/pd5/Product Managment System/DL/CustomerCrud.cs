using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class CustomerCrud
    {
        public static List<Customer> Customers = new List<Customer>();
        public static void AddCustomer(Customer Customer)
        {
            Customers.Add(Customer);
        }  
        public static bool ValidateCustomer(string name, string pass)
        {
            foreach (Customer customer in Customers)
            {
                int i = 0;
                if (customer.UserName == name && customer.Password == pass)
                {
                    Program.index = i;
                    return true;
                }
                i++;
            }
            return false;
        }
        public static void BuyProduct()
        {
            string prodName = ProductUi.GetProductName();
            int prodToBuyIndex = ProductCrud.FindProductByName(prodName);
            if (prodToBuyIndex != 1)
            {
                if (ProductCrud.Products[prodToBuyIndex].Stock > 0)
                {
                    ProductCrud.Products[prodToBuyIndex].Stock--;
                    Customers[Program.index].Cart.Add(ProductCrud.Products[prodToBuyIndex]);
                    Console.WriteLine("Product added to cart");
                }
                else
                {
                    Utility.DisplayError("Product out of stock");
                }
            }
            else
            {
                Utility.DisplayError("Product not found");
            }
        }
        public static string ViewCredentials()
        {
            string msg = Customers[Program.index].GetInfo();
            return msg;
        }
        public static string GenerateInvoice()
        {
            string invoice = "";
            int priceAfterTax = 0;
            int priceBeforeTax = 0;
            int totalPriceToPay = 0;
            
            foreach (Product product in Customers[Program.index].Cart)
            {
                priceBeforeTax = product.Price;
                priceAfterTax = product.CalculatePriceAfterTax();
                totalPriceToPay += priceAfterTax;
                invoice += $"{product.Name}, {priceBeforeTax}, {priceAfterTax}\n";
            }
            invoice += $"Total Price to Pay: ${totalPriceToPay}";
            
            return invoice;
        }
    }
}
