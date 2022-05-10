using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Vehicle_Catalogue
{
    class Car
    {
        public string Brand { get; set; }
        
        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] vehicleInfo = Console.ReadLine().Split('/', StringSplitOptions.RemoveEmptyEntries);

            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (vehicleInfo[0] != "end")
            {
                string type = vehicleInfo[0];
                string brand = vehicleInfo[1];
                string model = vehicleInfo[2];
                
                if (type == "Car")
                {
                    int hp = int.Parse(vehicleInfo[3]);
                    Car newCar = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = hp
                    };

                    cars.Add(newCar);
                }
                else if(type == "Truck")
                {
                    int weight = int.Parse(vehicleInfo[3]);
                    Truck newTruck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };

                    trucks.Add(newTruck);
                }

                vehicleInfo = Console.ReadLine().Split('/', StringSplitOptions.RemoveEmptyEntries);
            }

            List<Car> orderedCars = cars.OrderBy(currCar => currCar.Brand).ToList();
            List<Truck> orderedTrucks = trucks.OrderBy(currTruck => currTruck.Brand).ToList();

            if (orderedCars.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach(Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (orderedTrucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach(Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
