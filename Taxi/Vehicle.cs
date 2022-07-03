using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Vehicle
    {
        public int Price;
        public int MaxSpeed;
        public int ManufactureYear{get; private set;}

        public Vehicle(int manufactureYear, int price, int maxSpeed)
        {
            ManufactureYear = manufactureYear;
            Price = price;
            MaxSpeed = maxSpeed;
        }

    }
}
