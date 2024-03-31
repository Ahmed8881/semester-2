using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Bicycle
    {
        protected int cadence;
        protected int gear;
        protected int speed;

        public Bicycle(int cadence, int grar, int speed)
        {
            this.cadence = cadence;
            this.gear = grar;
            this.speed = speed;

        }
        public void SetCadence(int cadence)
        {
            this.cadence = cadence;
        }
        public void SetGear(int gear)
        {
            this.gear = gear;
        }
        public void ApplyBracke(int decrement)
        {
            speed -= decrement;
        }
        public void SpeedUp(int increment)
        {
            this.speed += increment;
        }
        public void ShowAllinfo()
        {
            Console.WriteLine("Candence" + cadence);
            Console.WriteLine("Gear" + gear);
            Console.WriteLine("Speed" + speed);
            
        }

    }
}
