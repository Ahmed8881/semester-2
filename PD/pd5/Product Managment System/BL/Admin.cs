using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class Admin
    {
        public string UserName;
        public string Password;
        public Admin(string name, string pass)
        {
            UserName = name;
            Password = pass;
        }
        public string GetInfo()
        {
            return $"{UserName}, {Password}";
        }
    }
}
