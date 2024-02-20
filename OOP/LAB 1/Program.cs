using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] studentData=new Student[5];
            for(int i = 0; i < 5; i++)
            {
                studentData[i]= takeStudentInput();
            }
            printStudentData(studentData);
            Console.Read();
        }
        static Student takeStudentInput() {
            Student s = new Student();
            Console.Write("Enter your name: ");
            s.sname = Console.ReadLine();
            Console.Write("Enter your matric marks: ");
            s.matricMarks=float.Parse(Console.ReadLine());
            Console.Write("Enter your fsc marks: ");
            s.fscMarks=float.Parse(Console.ReadLine());
            Console.Write("Enter your ecat marks: ");
            s.ecatMarks=float.Parse(Console.ReadLine());
            Console.WriteLine("              ");
            return s;
        }
        static void printStudentData(Student[] studentData) {
            Console.WriteLine("");
            Console.WriteLine("Name \t Matric \t Fsc \t Ecat ");
            for(int i=0;i<5;i++)
            {
                Console.WriteLine(studentData[i].sname + "\t" + studentData[i].matricMarks + "\t" + studentData[i].fscMarks + "\t" + studentData[i].ecatMarks);
            }
                }
    }
}
