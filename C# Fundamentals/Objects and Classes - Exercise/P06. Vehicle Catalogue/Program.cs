using System;
using System.Collections.Generic;

namespace P06._Vehicle_Catalogue
{
    class Vehicle
    {
        public string TypeOfVehicle { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string[] currVehicle = Console.ReadLine().Split(" ");

            int carCount = 0;
            int truckCount = 0;

            int totalCarsHorsePower = 0;
            int totalTrucksHorsePower = 0;

            while (currVehicle[0] != "End")
            {
                string type = currVehicle[0];
                string model = currVehicle[1];
                string color = currVehicle[2];
                int horsePower = int.Parse(currVehicle[3]);


                if (type == "car")
                {
                    carCount++;
                    totalCarsHorsePower += horsePower;
                }
                else if (type == "truck")
                {
                    truckCount++;
                    totalTrucksHorsePower += horsePower;
                }

                Vehicle newVehicle = new Vehicle
                {
                    TypeOfVehicle = type,
                    Model = model,
                    Color = color,
                    HorsePower = horsePower
                };

                vehicles.Add(newVehicle);

                currVehicle = Console.ReadLine().Split(" ");
            }


            string vehicleToPrint = Console.ReadLine();

            while (vehicleToPrint != "Close the Catalogue")
            {
                int indexOfVehicle = vehicles.FindIndex(x => x.Model == vehicleToPrint);

                Console.WriteLine($"Type: {char.ToUpper(vehicles[indexOfVehicle].TypeOfVehicle[0]) + vehicles[indexOfVehicle].TypeOfVehicle.Substring(1)}");
                Console.WriteLine($"Model: {vehicles[indexOfVehicle].Model}");
                Console.WriteLine($"Color: {vehicles[indexOfVehicle].Color}");
                Console.WriteLine($"Horsepower: {vehicles[indexOfVehicle].HorsePower}");

                vehicleToPrint = Console.ReadLine();
            }

            if (carCount > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(double)totalCarsHorsePower / carCount:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }
            if (truckCount > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(double)totalTrucksHorsePower / truckCount:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }
    }
}