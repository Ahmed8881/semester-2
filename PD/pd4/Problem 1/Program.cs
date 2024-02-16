using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Navigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
             List<Ship>ships = new List<Ship>();
            while(true) {
                Console.WriteLine("---OCEAN NAVIGATION----");
                Console.WriteLine("1-Add Ship");
                Console.WriteLine("2- View Ship position");
                Console.WriteLine("3-View ship serial number");
                Console.WriteLine("4- Change ship position");
                Console.WriteLine("5-Exit");
                Console.Write("Enter your option: ");
                int option= int.Parse(Console.ReadLine());
                if(option == 1) {
                    Addship(ships);
                }
                if (option == 2)
                {
                    Console.WriteLine("Enter the serial number to fing its positon: ");
                    string serialnum= Console.ReadLine();
                    for(int i = 0; i < ships.Count; i++)
                    {
                        if (ships.Any(s => s.shipNumber == serialnum)) {
                            string latitude = ships[i].viewShip("latitude");
                            string longitude = ships[i].viewShip("longitude");
                            Console.WriteLine($"Ship is at {latitude} and {longitude}");
                        }
                    }
                }
                if (option == 3) {
                    int count = 0;
                    Console.Write(" Enter Ship Latitude: ");
                   string lat = Console.ReadLine();
                    Console.Write(" Enter Ship Longitude: ");
                    string lon = Console.ReadLine();
                    for (int i = 0; i < ships.Count; i++)
                    {
                       string lati  = ships[i].viewShip("latitude");
                        string longi = ships[i].viewShip("langitude");
                        if (lati == lat && longi == lon)
                        {
                            Console.WriteLine($" Ships Serial Number is: {ships[i].shipNumber}");
                            count++;
                        }
                    }
                    if (count == 0)
                        Console.WriteLine(" No such ship found.");
                }
                if (option == 4)
               
            {
                   Console.WriteLine("Enter the serial number whose position you want to change: ");
                    string s_num= Console.ReadLine();
                    for(int i = 0; i < ships.Count; i++)
                    {
                        if (s_num == ships[i].shipNumber)
                        {
                            ships[i].changeposition();
                            

                        }
                        else { Console.Write("Ship not found"); }
                    }
                
                }
                if (option == 5)
                {
                    Console.Clear();
                    break;

                }


            }

        }
        static Ship Addship(List<Ship>ships)
        {
            Console.WriteLine("Enter ship number: ");
            string shipnum= Console.ReadLine();
            Angle1 logitude=takeDirections("logitude");
            Angle1 latitude = takeDirections("Latitude");
           Ship ship=new Ship(shipnum, logitude, latitude);
            ships.Add(ship);
            return ship;
        }
        static Angle1 takeDirections(string direction)
        {
            Console.WriteLine($"Enter ship {direction}");
            Console.WriteLine();
            Console.WriteLine($"Enter {direction} Degree:");
            int degree = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter {direction} Minute:");
            float minutes = float.Parse(Console.ReadLine());
            Console.WriteLine($"Enter {direction} Direction:");
            char directions = char.Parse(Console.ReadLine());
            Console.WriteLine();
            Angle1 angle = new Angle1(degree,minutes,directions);
            return angle;

        }
    }
}