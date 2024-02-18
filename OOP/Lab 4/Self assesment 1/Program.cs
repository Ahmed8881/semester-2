using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_assessment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.name = "Ahmed";
            student.rollnum = 18;
            student.cgpa = 3.9F;
            student.MatricMarks = 1096;
            student.fscMarks = 1031;
            student.EcatMarks = 312;
            student.homeTown = "Lahore";
            student.isHostalite = true;
            student.isTakingScholarship = true;
            float meritPer = student.calculateMerit();
            bool isEligible = student.IsEligibleforScholarship(meritPer);
            Console.WriteLine("Merit percentage "+meritPer);
            Console.WriteLine("Is Eligible for scholarshiip " + isEligible);

        }
    }
}
