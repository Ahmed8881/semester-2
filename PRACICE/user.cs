using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsingn
{
   
    internal class user
    {
        public user(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;

        }
        string name;
        string password;
        string role;
    }
}
