using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            List<Student> students = new List<Student>();
            List<Degree> degrees = new List<Degree>();
            List<Subject> subjects = new List<Subject>();
            while (true)
            {
                Console.WriteLine("\t\t\t University Admission MANAGEMENT SYSTEM (UAMS)");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Degree Program");
                Console.WriteLine("3. Add Subjects in a specific Degree");
                Console.WriteLine("4. Generate Merit");
                Console.WriteLine("5. View Registered Students");
                Console.WriteLine("6. View Students of a specific Program");
                Console.WriteLine("7. Register Subjects for a specific Student");
                Console.WriteLine("8. Calculate Fee for all registered Students");
                Console.WriteLine("9. Exit");
                Console.Write("Enter Option Number: ");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tAdd Student\n\n");
                    if (degrees.Count > 0)
                        students.Add(addstudent(degrees));
                    else
                        Console.WriteLine(" No Degree Program Available");
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tAdd Degree Program\n\n");
                    degrees.Add(adddegree(subjects));
                }
                else if (option == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tAdd Subjects in a specific Degree\n\n");
                    adddegreesubjects(subjects,degrees);
                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t Calculate Merit\n\n");
                    List<Student> sortedstudents = new List<Student>();
                    foreach (Student s in students)
                    {
                        s.calculatemerit();
                    }
                    sortedstudents = students.OrderByDescending(o => o.merit).ToList();
                    giveadmission(sortedstudents);
                }
                else if (option == 5)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t View Registered students\n\n");
                    Console.WriteLine("Student Name \t\t Student Age \t\t FSC Marks \t\t ECAT Marks");
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].degreeregistered != null)
                        {
                            students[i].viewstudent();
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" \n\nNo Registered Student Exist.");
                }
                else if (option == 6)
                {
                    count = 0;
                    string deg = "";
                    Console.Clear();
                    Console.WriteLine("\t\t\t View Student of a specific degree\n\n");
                    Console.Write(" Enter Degree Name: ");
                    deg = Console.ReadLine();
                    Console.WriteLine("\n\nStudent Name \t\t Student Age \t\t FSC Marks \t\t ECAT Marks");
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].degreeregistered != null && students[i].degreeregistered.degreetitle == deg)
                        {
                            students[i].viewstudent();
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" \n\n No Such Student Exist.");
                }
                else if (option == 7)
                {
                    string na = " ";
                    string co = " ";
                    Subject sub=new Subject("0","0",0,0);
                    Console.Clear();
                    Console.WriteLine("\t\t\t Register Subjects for a specific Student\n\n");
                    Console.Write(" Enter Student Name: ");
                    na = Console.ReadLine();
                    Console.Write(" Enter Subject Code you want to register: ");
                    co = Console.ReadLine();
                    for (int i = 0; i < subjects.Count; i++)
                    {
                        if (subjects[i].subjectcode == co)
                        {
                            sub = subjects[i];
                        }
                    }
                    for (int n = 0; n < students.Count; n++)
                    {
                        if (students[n].name == na)
                        {
                            if (students[n].addstudentsubject(sub)) 
                            Console.WriteLine(" Subject is successfully added.");

                            else
                                Console.WriteLine(" A problem occurs while adding subject.");
                        }
                    }
                }
                else if (option == 8)
                {
                    count = 0;
                    Console.Clear();
                    Console.WriteLine("\t\t\t Calculate Fee for all registered Students\n\n");
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].degreeregistered != null)
                        {
                            students[i].calculatefee();
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" \n\nNo Registered Student Exist.");
                }
                else if (option == 9)
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine("\n\nPress any Key to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static Student addstudent(List<Degree> degrees)
        {
            string name;
            double fsc, ecat;
            int age, pref;
            int count = 0;
            string preference;
            List<Degree> preferencelist = new List<Degree>();
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter Inter Marks: ");
            fsc = double.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks: ");
            ecat = double.Parse(Console.ReadLine());
            Console.Write(" Enter number of Preferences: ");
            pref = int.Parse(Console.ReadLine());
            for (int i = 0; i < pref; i++)
            {
                Console.Write(" Enter Preference {0}: ", i + 1);
                preference = Console.ReadLine();
                for (int j = 0; j < degrees.Count; j++)
                {
                    if (preference == degrees[j].degreetitle && degrees[j].seats > 0)
                    {
                        preferencelist.Add(degrees[j]);
                        count++;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine(" The requested degree program is not available.");
                    i--;
                    count = 0;
                }
            }
            Student s1 = new Student(name, age, fsc, ecat, preferencelist);
            return s1;
        }
        static Degree adddegree(List<Subject> subjects)
        {
            string degtitle, subcode, subtype;
            int number, duration, credithours, seats;
            double fee;
            Console.Write(" Enter Degree Name: ");
            degtitle = Console.ReadLine();
            Console.Write(" Enter Degree Duration: ");
            duration = int.Parse(Console.ReadLine());
            Console.Write(" Enter Seats for Degree: ");
            seats = int.Parse(Console.ReadLine());
            Degree deg1 = new Degree(degtitle, duration, seats);
            Console.Write("How many subjects you want to add in Degree: ");
            number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Console.Write("Enter subject {0} code: ", i + 1);
                subcode = Console.ReadLine();
                Console.Write("Enter subject {0} type: ", i + 1);
                subtype = Console.ReadLine();
                Console.Write("Enter subject {0} Credit Hours: ", i + 1);
                credithours = int.Parse(Console.ReadLine());
                Console.Write("Enter subject {0} Fees: ", i + 1);
                fee = double.Parse(Console.ReadLine());
                Subject sub = addinsubjectlist(subcode, subtype, credithours, fee);
                subjects.Add(sub);
                if (deg1.addsubject(sub))
                {
                    Console.WriteLine(" Subject cannot be added as Limit of credit hours is exceeded.");

                    break;
                }
            }
            return deg1;
        }
        static void adddegreesubjects(List<Subject> subjects, List<Degree> degrees)
        {
            int count = 0;
            string degrtitle, subjcode, subjtype;
            int credhours;
            double fees;
            Console.Write(" Enter Degree Name: ");
            degrtitle = Console.ReadLine();
            Console.Write("Enter subject code: ");
            subjcode = Console.ReadLine();
            Console.Write("Enter subject type: ");
            subjtype = Console.ReadLine();
            Console.Write("Enter subject Credit Hours: ");
            credhours = int.Parse(Console.ReadLine());
            Console.Write("Enter subject Fees: ");
            fees = double.Parse(Console.ReadLine());
            Subject sub = addinsubjectlist(subjcode, subjtype, credhours, fees);
            subjects.Add(sub);
            for (int i = 0; i < degrees.Count; i++)
            {
                if (degrees[i].degreetitle == degrtitle)
                {
                    count++;
                    if (degrees[i].addsubject(sub))
                    {
                        Console.WriteLine(" Subject cannot be added as Limit of credit hours is exceeded.");
    
                }
                }
            }
            if (count == 0)
                Console.WriteLine(" No such degree Exist.");
        }
        static Subject addinsubjectlist(string subcode, string subtype, int credithours, double fee)
        {
            Subject sub1 = new Subject(subcode, subtype, credithours, fee);
            return sub1;
        }
        static void giveadmission(List<Student> sortedstudents)
        {
            int counter = 0;
            foreach (Student s in sortedstudents)
            {
                counter = 0;
                foreach (Degree d in s.preferences)
                {
                    if (s.degreeregistered == null && d.seats > 0)
                    {
                        s.degreeregistered = d;
                        d.seats--;
                        Console.WriteLine($" {s.name} got admission in {d.degreetitle}");
                        counter++;
                    }
                    if (counter == 0)
                        Console.WriteLine($" {s.name} did not get admission.");

                    }
            }
        }
    }
}

