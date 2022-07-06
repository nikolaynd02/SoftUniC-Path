using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int cmds = int.Parse(Console.ReadLine());

            while(cmds-- > 0)
            {
                string[] cmdInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdInfo[0];
                string vehicle = cmdInfo[1];
                double amount = double.Parse(cmdInfo[2]);

                if(vehicle == "Car")
                {
                    if(cmdType == "Drive")
                    {
                        if (car.CanDrive(amount))
                        {
                            car.Drive(amount);
                            Console.WriteLine($"Car travelled {amount} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else
                    {
                        car.Refuel(amount);
                    }
                }
                else if(vehicle == "Truck")
                {
                    if (cmdType == "Drive")
                    {
                        if (truck.CanDrive(amount))
                        {
                            truck.Drive(amount);
                            Console.WriteLine($"Truck travelled {amount} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }
                else
                {
                    if (cmdType == "Drive")
                    {
                        if (bus.CanDrive(amount))
                        {
                            bus.Drive(amount);
                            Console.WriteLine($"Bus travelled {amount} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        if (bus.CanDrive(amount))
                        {
                            bus.DriveEmpty(amount);
                            Console.WriteLine($"Bus travelled {amount} km");
                        }
                        else
                        {
                            Console.WriteLine("Bus needs refueling");
                        }
                    }
                    else
                    {
                        bus.Refuel(amount);
                    }
                }
            }

            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
            Console.WriteLine($"Bus: {bus.Fuel:F2}");
        }
    }
}
