using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_3_new_PD
{
    internal class MenuCrud
    {
        public static List<MenuItem> MenuItems = new List<MenuItem>();
        public static void LoadMenuItems()
        {
            StreamReader File = new StreamReader("ItemsData.csv");
            string line;
            while ((line = File.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                MenuItem newItem = new MenuItem(data[0], data[1], int.Parse(data[2]));  // create menu object
                MenuItems.Add(newItem);
            }
            File.Close();
        }
        public static MenuItem GetItemDetails(string nameOfItem)
        {
            foreach (MenuItem M in MenuItems)
            {
                if (nameOfItem == M.Name)
                {
                    return M;
                }
            }
            return null;
        }
        public static void AddItem(MenuItem item)
        {
            MenuItems.Add(item);
        }
    }
}
