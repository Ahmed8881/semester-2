using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    internal class Angle1
    {
        public int degree;
        public float minutes;
        public char direction;
        public Angle1(int degree, float minutes, char direction)
        {
            this.degree = degree;
            this.minutes = minutes;
            this.direction = direction;

        }
        public string getValue()
        {
            Console.Write("Enter the degree: ");
            int degree=int.Parse(Console.ReadLine());
            Console.Write("Enter the minutes: ");
            float minutes=float.Parse(Console.ReadLine());
            Console.Write("Enter the direction: ");
            char direction=char.Parse(Console.ReadLine());

            return $"{degree}°{minutes} {direction}";
        }
    }
}
