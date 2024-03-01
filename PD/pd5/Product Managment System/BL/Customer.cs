using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class Customer
    {
        public string UserName;
        public string Password;
        public string Email;
        public string Address;
        public string Contact;
        public List<Product> Cart = new List<Product>();
        public Customer(string userName, string password, string email, string address, string contact)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Address = address;
            Contact = contact;
        }
        public string GetInfo()
        {
            string msg = $"{UserName}, {Password}, {Email}, {Address}, {Contact}";
            return msg;
        }
    }
}
