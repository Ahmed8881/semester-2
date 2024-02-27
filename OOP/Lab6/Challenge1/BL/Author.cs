using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class Author
    {
        private string Name; 
        private string Email;
        private string Gender;
        public string GetName()
        {
            return Name;
        }
        public string GetEmail()
        {
            return Email;
        }
        public string GetGender()
        {
            return Gender;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public void SetEmail(string Email)
        {
            this.Email = Email;
        }
        public void SetGender(string Gender)
        {
            this.Gender= Gender;
        }
        public Author(string Name,string Email,string Gender )
        {
            this.Name= Name;
            this.Email= Email;
            this.Gender= Gender;

        }

    }
}
