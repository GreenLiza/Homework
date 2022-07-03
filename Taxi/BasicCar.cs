using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    internal class BasicCar:Vehicle
    {
        public double FuelConsumption;
        public string Brand;

        internal BasicCar(int manufactureYear, int price, int maxSpeed, double fuelConsumption, string brand) : base(manufactureYear, price, maxSpeed)
        {
            FuelConsumption = fuelConsumption;
            Brand = brand;
        }

        public virtual string PrintInfo()
        {
            return $"{Brand}: price - {Price}$, year - {ManufactureYear}, maximum speed - {MaxSpeed}km/h, fuel consumption - {FuelConsumption}l.";
        }

        public virtual string PrintSimpleInfo()
        {
            return $"{ManufactureYear} {Price} {MaxSpeed} {FuelConsumption} {Brand}";
        }
    }
}
