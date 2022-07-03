using System;
using System.Collections.Generic;
using System.IO;

namespace Taxi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BasicCar> taxi = GetCarsFromFile();
            if (taxi.Count == 0)
            {
                taxi = CreateTaxiCarsList();
            }
            PrintTaxiCarsInfo(taxi);

            int taxiCarsPrice = CountAllCarsPrice(taxi);
            Console.WriteLine($"Total price of all taxi cars = {taxiCarsPrice}$.\n");

            SortCarsByFuelConsumption(taxi);

            FindCarsBySpeed(taxi);

            AddCarsToFile(taxi);

        }

        static List<BasicCar> CreateTaxiCarsList()
        {
            BasicCar BMW = new BasicCar(2018, 42000, 200, 10.5, "BMW");
            BasicCar Opel = new BasicCar(2010, 13000, 170, 7.2, "Opel");
            BasicCar Renault = new BasicCar(2013, 9700, 150, 6.3, "Renault");
            PremiumCar Mustang = new PremiumCar(2018, 52000, 200, 13.7, "Mustang", "AppleCar");
            PremiumCar Mazda = new PremiumCar(2017, 47000, 220, 11.9, "Mazda", "AndroidAuto");
            PremiumCar Nissan = new PremiumCar(2018, 25000, 180, 9.0, "Nissan", "YandexAuto");

            List<BasicCar> taxi = new List<BasicCar>() { BMW, Opel, Renault, Mustang, Mazda, Nissan };

            return taxi;

        }

        static void AddCarsToFile(List<BasicCar> taxi)
        {
            var carsFilePath = "cars.txt";
            string[] carsInfo = new string[taxi.Count];
            for (int i = 0; i < taxi.Count; i++)
            {
                carsInfo[i] = taxi[i].PrintSimpleInfo();
            }

            File.WriteAllLines(carsFilePath, carsInfo);
        }

        static List<BasicCar> GetCarsFromFile()
        {
            var taxiList = new List<BasicCar>();

            if (File.Exists("cars.txt"))
            {
                string[] carsInfo = File.ReadAllLines("cars.txt");


                foreach (string s in carsInfo)
                {
                    var carData = s.Split(" ");
                    if (carData.Length == 5 || carData.Length == 6)
                    {
                        Int32.TryParse(carData[0], out int manYear);
                        Int32.TryParse(carData[1], out int price);
                        Int32.TryParse(carData[2], out int maxSpeed);
                        Double.TryParse(carData[3], out double fuelCons);

                        BasicCar car;
                        if (carData.Length == 5)
                        {
                            car = new BasicCar(manYear, price, maxSpeed, fuelCons, carData[4]);
                        }
                        else
                        {
                            car = new PremiumCar(manYear, price, maxSpeed, fuelCons, carData[4], carData[5]);

                        }
                        taxiList.Add(car);
                    }
                }
            }

            return taxiList;
        }

        static void PrintTaxiCarsInfo(List<BasicCar> taxi)
        {
            foreach (BasicCar car in taxi)
            {
                Console.WriteLine(car.PrintInfo());
            }
            Console.WriteLine();
        }

        static int CountAllCarsPrice(List<BasicCar> taxi)
        {
            var allCarsPrice = 0;
            for (int i = 0; i < taxi.Count; i++)
            {
                allCarsPrice += taxi[i].Price;
            }


            return allCarsPrice;
        }

        static void SortCarsByFuelConsumption(List<BasicCar> taxi)
        {
            for (int j = 0; j < taxi.Count; j++)
            {
                for (int i = j; i < taxi.Count; i++)
                {
                    BasicCar change;
                    if (taxi[j].FuelConsumption > taxi[i].FuelConsumption)
                    {
                        change = taxi[j];
                        taxi[j] = taxi[i];
                        taxi[i] = change;
                    }
                }
            }

            PrintBrandAndFuelConsumption(taxi);
        }

        static void PrintBrandAndFuelConsumption(List<BasicCar> taxi)
        {
            foreach (BasicCar car in taxi)
            {
                Console.WriteLine($"{car.Brand} - fuel consumption is {car.FuelConsumption}l.");
            }
            Console.WriteLine();
        }

        static void FindCarsBySpeed(List<BasicCar> taxi)
        {
            Console.WriteLine("Enter the speed you want to reach: ");
            var check = Int32.TryParse(Console.ReadLine(), out int maximum);
            if (check)
            {
                for (int i = 0; i < taxi.Count; i++)
                {
                    if (taxi[i].MaxSpeed >= maximum)
                    {
                        Console.WriteLine($"{taxi[i].Brand} - maximum speed is {taxi[i].MaxSpeed}km/h.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect input :(");
                FindCarsBySpeed(taxi);
            }
            
        }
    }
}
