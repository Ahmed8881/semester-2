using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    internal class Flight_Details
    {
        public Flight_Details(string Route,int price,int seat_Num,string time)
        { 
            this.Route = Route;
            this.Price = price;
            this.seat_Num = seat_Num;
            this.time = time;
            
        }
        public string Route;
        public int Price;
        public int seat_Num;
        public string time;
    }
}
