//using chlng1_new_pf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class AdminCrud
    {
     
        public static List<Admin> Admins = new List<Admin>();
        public static void AddAdmin(Admin Admin)
        {
            Admins.Add(Admin);
        }
        public static bool ValidateAdmin(string name, string pass)
        {
            int i = 0;
            foreach (Admin admin in Admins)
            {
                if (admin.UserName == name && admin.Password == pass)
                {
                    Program.index = i;
                    return true;
                }
                i++;
            }
            return false;
        }
        public static string ViewCredentials()
        {
            return Admins[Program.index].GetInfo();
        }
    }
}
