using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MountainBike bike = new MountainBike(5,5,7,10);
            bike.SetGear(3);
            bike.SetCadence(6);
            bike.ApplyBracke(1);
            bike.SpeedUp(5);
            bike.ShowAllinfo();
            Console.ReadKey();
            
        }
    }
}
