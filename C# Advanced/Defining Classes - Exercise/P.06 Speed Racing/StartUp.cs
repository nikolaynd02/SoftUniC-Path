using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());

            Dictionary<string,Car> cars = new Dictionary<string,Car>();

            for(int i = 0; i < numOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuel = double.Parse(carInfo[1]);
                double fuelPerKm = double.Parse(carInfo[2]);

                Car currCar = new Car();
                currCar.Model = model;
                currCar.Fuelamount = fuel;
                currCar.FuelConsumptionPerKilometer = fuelPerKm;

                cars.Add(model, currCar);
            }

            string command = string.Empty;

            while((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();
                string model = info[1];
                double distance = int.Parse(info[2]);

                cars[model].Drive(distance);
            }

            foreach(var kvp in cars)
            {
                Console.WriteLine($"{kvp.Value.Model} {kvp.Value.Fuelamount:f2} {kvp.Value.TravelledDistance}");
            }
        }
    }
}
