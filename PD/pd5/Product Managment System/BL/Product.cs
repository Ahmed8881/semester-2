using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlng1_new_pf
{
    internal class Product
    {
        public string Name;
        public string Category;
        public int Price;
        public int Stock;
        public int MinStock;
        public Product(string name, string category, int price, int stock, int minstock)
        {
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
            MinStock = minstock;
        }
        public string GetInfo()
        {
            return $"{Name}, {Category}, {Price}, {Stock}, {MinStock}";
        }
        public string FileStorage()
        {
            return $"{Name},{Category},{Price},{Stock},{MinStock}";
        }
        public int SalesTax()
        {
            int salesTax = 0;
            if ( Category == "Fruits")
            {
                salesTax = 5;
            }
            else if (Category == "Grocery")
            {
                salesTax = 10;
            }
            else
            {
                salesTax = 15;
            }
            return salesTax;
        }
        public int CalculatePriceAfterTax()
        {
            return Price - (Price * SalesTax()/100);   // price - sales tax on price
        }
        public bool IsReorderNeeded()
        {
            if (Stock <= MinStock)
            {
                return true;
            }
            return false;
        }
    }
}
