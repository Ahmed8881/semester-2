using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paraCanstructortask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student s1=new student("Ahmed",500,500,400);
            student s2 = new student("Ali", 550, 550, 390);
            Console.WriteLine(s1.sname + " \t" + s1.matricMarks + "\t " + s1.fscmarks + "\t " + s1.ecatMarks);
            Console.WriteLine(s2.sname + " \t" + s2.matricMarks + "\t " + s2.fscmarks + " \t" + s2.ecatMarks);
            Console.ReadKey();

        }
    }
}
