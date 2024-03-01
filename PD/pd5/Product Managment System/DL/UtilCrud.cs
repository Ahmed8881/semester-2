using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng1_new_pf
{
    internal class UtilCrud
    {
        public static bool Validate(string type)
        {
            string name = Utility.GetName();
            string pass = Utility.GetPassword();

            bool flag = false;
            if (type == "admin")
            {
                flag = AdminCrud.ValidateAdmin(name, pass);
            }
            else
            {
                flag = CustomerCrud.ValidateCustomer(name, pass);
            }
            return flag;   // return true if login is successful
        }
    }
}
