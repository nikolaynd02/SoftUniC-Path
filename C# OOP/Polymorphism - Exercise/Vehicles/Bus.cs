using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuel, double consumption, double capacity) : base(fuel, consumption + 1.4, capacity)
        {

        }

        public void DriveEmpty(double distance)
        {
            this.Consumption -= 1.4;

            Drive(distance);

            this.Consumption += 1.4;
        }
    }
}
