using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumption, double capacity) : base(fuel, consumption + 1.6, capacity)
        {

        }

        public override void Refuel(double amount)
        {
            if (amount > 0)
            {
                if (this.Fuel + amount > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                }
                else
                {
                    this.Fuel += (amount * 95 / 100);
                }
            }
            else
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
        }
    }
}
