using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class login
    {

        public string name;
        public int password;
        public string role;

        public login(string signupname, int signuppassword, string rol)
        {
            this.name = signupname;
            this.password = signuppassword;
            this.role = rol;
        }
    }
}
