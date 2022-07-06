using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {

        public Vehicle(double fuel, double consumption, double capacity)
        {
            this.TankCapacity = capacity;
            this.Consumption = consumption;
            if (capacity < fuel)
            {
                this.Fuel = 0;
            }
            else
            {
                this.Fuel = fuel;
            }
        }
        public double Fuel { get; set; }
        public double Consumption { get; set; }
        public double TankCapacity { get; set; }


        public bool CanDrive(double distance)
        {
            return this.Consumption * distance <= this.Fuel;
        }

        public void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                this.Fuel -= this.Consumption * distance;
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount > 0)
            {
                if(this.Fuel + amount > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                }
                else
                {
                    this.Fuel += amount;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }

    }
}
