using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Speed_Racing
{
    class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double DistanceTravelled { get; set; }

        public void Drive(double kilometers)
        {
            if (this.FuelConsumption * kilometers <= FuelAmount)
            {
                this.FuelAmount -= this.FuelConsumption * kilometers;
                this.DistanceTravelled += kilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numofCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for(int i = 0; i < numofCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuel = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);

                Car newCar = new Car()
                {
                    Model = model,
                    FuelAmount = fuel,
                    FuelConsumption = fuelConsumption
                };
                cars.Add(newCar);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] driveInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = driveInfo[1];
                double distance = double.Parse(driveInfo[2]);

                int carIndex = cars.FindIndex(x => x.Model == model);
                cars[carIndex].Drive(distance);

                input = Console.ReadLine();
            }

            foreach(Car currCar in cars)
            {
                Console.WriteLine($"{currCar.Model} {currCar.FuelAmount:f2} {currCar.DistanceTravelled}");
            }

        }
    }
}
