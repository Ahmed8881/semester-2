using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class Subject
    {
        public string subjectcode;
        public string subjecttype;
        public int credithours;
        public double subjectfee;

        public Subject(string subjectcode, string subjecttype, int credithours, double subjectfee)
        {
            this.subjectcode = subjectcode;
            this.subjecttype = subjecttype;
            this.credithours = credithours;
            this.subjectfee = subjectfee;
        }
    }
}
