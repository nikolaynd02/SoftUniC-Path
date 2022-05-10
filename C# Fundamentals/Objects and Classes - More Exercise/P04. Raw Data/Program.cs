using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Raw_Data
{
    class Engine
    {
        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }
    }

    class Cargo
    {
        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }
    class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Car()
        {
            Engine = new Engine();
            Cargo = new Cargo();
        }

        public void PrintCar()
        {
            Console.WriteLine($"{this.Model}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for(int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Car newCar = new Car()
                {
                    Model = model,
                    Engine = new Engine()
                    {
                        EnginePower = enginePower,
                        EngineSpeed = engineSpeed
                    },
                    Cargo = new Cargo()
                    {
                        CargoType = cargoType,
                        CargoWeight = cargoWeight
                    }
                };

                cars.Add(newCar);
            }

            string typeOfCargo = Console.ReadLine();

            if (typeOfCargo == "fragile")
            {
                List<Car> filtered = cars.Where(x => x.Cargo.CargoType == typeOfCargo && x.Cargo.CargoWeight < 1000).ToList();

                foreach (Car currCar in filtered)
                {
                    currCar.PrintCar();
                }
            }
            else
            {
                List<Car> filtered = cars.Where(x => x.Cargo.CargoType == typeOfCargo && x.Engine.EnginePower > 250).ToList();

                foreach (Car currCar in filtered)
                {
                    currCar.PrintCar();
                }
            }
        }
    }
}
