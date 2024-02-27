using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_3_new_PD
{
    internal class MenuItem
    {
        public string Name;
        public string Type;
        public int Price;

        public MenuItem(string name, string type, int price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

    }
}
