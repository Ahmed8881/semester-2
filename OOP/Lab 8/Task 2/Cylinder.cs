using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Cylinder: Circle
    {
        private double height;
        public Cylinder()
        {
        }
        public Cylinder(double radius)
        {
            SetRadius(radius);
        }
        public Cylinder(double radius, double height)
        {
            SetRadius(radius);
            this.height = height;
        }
        public Cylinder(double radius, double height, string color)
        {
            SetRadius(radius);
            this.height = height;
            SetColor(color);
        }
        public double GetHeight()
        {
            return height;
        }
        public void SetHeight(double height)
        {
            this.height = height;
        }
        public double GetVolume()
        {
            return GetArea() * height;
        }

    }
}
