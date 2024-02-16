using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    internal class MUser
    {
        public MUser(string username,string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public MUser(string username,string password) { 
               this.username=username;
            this.password=password;
        }
        public  string username;
        public  string password;
        public string role;
        public bool isAdmin()
        {
            if(role == "Admin" || role=="admin")
            { 
                return true;
            }
            else
                return false;
        }

    }
}
