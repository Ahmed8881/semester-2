using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task4
{
    internal class Degree
    {
        public string degreetitle;
        public int duration;
        public int seats;
        List<Subject> subjectsadd = new List<Subject>();

        public Degree(string degreetitle, int duration, int seats)
        {
            this.degreetitle = degreetitle;
            this.duration = duration;
            this.seats = seats;
        }

        public bool addsubject(Subject sub)
        {
            int totalcredithours = calculatecredithours()+sub.credithours;
            if (totalcredithours <= 20)
            {
                subjectsadd.Add(sub);
                return false;
            }
            return true;
        }
        public bool issubjectexist(Subject sub)
        {
            for (int i = 0; i < subjectsadd.Count; i++)
            {
                if (subjectsadd[i].subjectcode == sub.subjectcode)
                    return true;
            }
            return false;
        }
        public int calculatecredithours()
        {
            int hours = 0;
            for (int i = 0; i < subjectsadd.Count; i++)
            {
                hours = hours + subjectsadd[i].credithours;
            }
            return hours;
        }
    }
}
