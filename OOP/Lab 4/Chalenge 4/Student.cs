using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task4
{
    internal class Student
    {
        public string name;
        public int age;
        public double fscmarks;
        public double ecatmarks;
        public double merit;
        public List<Degree> preferences = new List<Degree>();
        public Degree degreeregistered;
        public List<Subject> subjectsregistered = new List<Subject>();

        public Student(string name, int age, double fscmarks, double ecatmarks, List<Degree> preferencelist)
        {
            this.name = name;
            this.age = age;
            this.fscmarks = fscmarks;
            this.ecatmarks = ecatmarks;
            this.merit = 0F;
            for (int i = 0; i < preferencelist.Count; i++)
                preferences.Add(preferencelist[i]);
        }

        public void calculatemerit()
        {
            merit = (((fscmarks / 1100) * 0.5F) + ((ecatmarks / 1100) * 0.5F)) * 100;
        }
        public void viewstudent()
        {
            Console.WriteLine("{0} \t\t \t  {1} \t\t\t {2} \t\t\t {3}", name, age, fscmarks, ecatmarks);
        }
        public void calculatefee()
        {
            double totalfee = 0;
            for (int x = 0; x < subjectsregistered.Count; x++)
            {
                totalfee += subjectsregistered[x].subjectfee;
            }
            Console.WriteLine($" {name} has {totalfee} fees.");
        }
        public int getcredithours()
        {
            int hours = 0;
            for (int i = 0; i < subjectsregistered.Count; i++)
            {
                hours = hours + subjectsregistered[i].credithours;
            }
            return hours;
        }
        public bool addstudentsubject(Subject sub)
        {
            int cred = getcredithours()+sub.credithours;
            if (degreeregistered != null && cred <= 9 && degreeregistered.issubjectexist(sub))
            {
                subjectsregistered.Add(sub);
                return true;
            }
            return false;
        }
    }
}
