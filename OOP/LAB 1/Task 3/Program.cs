using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            students a= new students();
            Console.WriteLine(a.sname);
            Console.WriteLine(a.matricMarks);
            Console.WriteLine(a.fscMarks);
            Console.WriteLine(a.ecatMarks);
            Console.WriteLine(a.aggregate);
            Console.ReadKey();
           
        }
    }
}

