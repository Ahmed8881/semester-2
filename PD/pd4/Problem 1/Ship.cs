using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    class Ship
    {
        public string shipNumber;
        public Angle1 Latitude;
        public Angle1 Longitude;
        public Ship(string shipNumber,Angle1 Latitude,Angle1 Longitude) { 
            this.shipNumber = shipNumber;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
        public string viewShip(string dir)
        {
            if(dir == "latitude")
            {
                return ($"{Longitude.degree}° {Longitude.minutes}° {Longitude.direction}");
                    
            }
            return ($"{Latitude.degree}° {Latitude.minutes}° {Latitude.direction}");
        }
        public void changeposition()
        {
            int latdegree;
            float latminutes = 0F;
            char latdir;
            int londegree; 
            float lonminutes = 0F;
            char londir;
            Console.WriteLine(" Enter Ship Latitude: ");
            Console.Write(" Enter Latitude's Degree: ");
            latdegree = int.Parse(Console.ReadLine());
            Console.Write(" Enter Latitude's Minutes: ");
            latminutes = float.Parse(Console.ReadLine());
            Console.Write(" Enter Latitude's Direction: ");
            latdir = char.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Ship Longitude: ");
            Console.Write(" Enter Longitude's Degree: ");
            londegree = int.Parse(Console.ReadLine());
            Console.Write(" Enter Longitude's Minutes: ");
            lonminutes = float.Parse(Console.ReadLine());
            Console.Write(" Enter Longitude's Direction: ");
            londir =char.Parse( Console.ReadLine());
            Latitude.degree = latdegree;
            Latitude.minutes = latminutes;
            Latitude.direction = latdir;
            Longitude.degree = londegree;
            Longitude.minutes = lonminutes;
            Longitude.direction = londir;
            Console.WriteLine(" The Loaction of ship is successfully changed.");
        }

      

    }
}
