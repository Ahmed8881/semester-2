using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsingn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<user> userDetail = new List<user>();
            sign_up(userDetail);
        }
        static void sign_up(List <user>userDetail) {
            Console.Write("Enter your name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your password: ");
            string pass=Console.ReadLine(); 
            Console.Write("Enter your role: ");
            string role=Console.ReadLine(); 
            user u1=new user(name,pass,role);
            userDetail.Add(u1);

        }

    }
}
