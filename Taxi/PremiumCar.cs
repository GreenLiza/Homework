using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    internal class PremiumCar:BasicCar
    {
        public string Assistant;

        internal PremiumCar(int manufactureYear, int price, int maxSpeed, double fuelConsumption, string brand, string assistant) : base(manufactureYear, price, maxSpeed, fuelConsumption, brand)
        {
            Assistant = assistant;
        }

        public override string PrintInfo()
        {
            return $"{Brand}: price - {Price}$, year - {ManufactureYear}, maximum speed - {MaxSpeed}km/h, fuel consumption - {FuelConsumption}l, car assistant - {Assistant}.";
        }

        public override string PrintSimpleInfo()
        {
            return $"{ManufactureYear} {Price} {MaxSpeed} {FuelConsumption} {Brand} {Assistant}";
        }
    }
}
