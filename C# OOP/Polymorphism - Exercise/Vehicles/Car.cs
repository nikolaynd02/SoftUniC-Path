using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuel, double consumption, double capacity) : base(fuel, consumption + 0.9, capacity)
        {
                
        }
    }
}
