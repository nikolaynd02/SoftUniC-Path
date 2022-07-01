using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;        
        private double fuel;
        private int horsePower;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;
       

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }


        public virtual void Drive(double kilometers)
        {
            if(this.fuel >= kilometers * this.FuelConsumption)
            {
                this.fuel -= kilometers * this.FuelConsumption;
            }
           
        }
    }
}
