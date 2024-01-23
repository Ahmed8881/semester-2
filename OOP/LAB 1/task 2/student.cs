using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paramereizedConstructor
{
    internal class student
    {
        public student(string n) {
            sname=n;
        }
         
        public string sname;
        public float matricMarks;
        public float fscmarks;
        public float ecatmarks;

    }
}
