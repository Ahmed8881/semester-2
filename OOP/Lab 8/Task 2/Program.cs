using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cylinder cylinder = new Cylinder(5.0, 2.0, "blue");
           string output=cylinder.ToString();
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
