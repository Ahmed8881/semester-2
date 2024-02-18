using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_assessment_1
{
    internal class Student
    {
        public string name;
        public int rollnum;
        public float cgpa;
        public int fscMarks;
        public int MatricMarks;
        public int EcatMarks;
        public string homeTown;
        public bool isHostalite;
        public bool isTakingScholarship;
        public float calculateMerit()
        {
            int total = MatricMarks+fscMarks+EcatMarks;
            float merit=(total/300)*100;
            return merit;
    }
        public bool IsEligibleforScholarship(float meritPercentage)
        {
            if (meritPercentage > 80)
            {
                return true;
            }
            return false;
        }
    }
   
}
