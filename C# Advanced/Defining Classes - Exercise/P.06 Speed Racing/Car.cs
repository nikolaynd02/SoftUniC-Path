using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model 
        {
            get { return model; }
            set { model = value; }
        }
        public double Fuelamount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(double distance)
        {
            if (distance * fuelConsumptionPerKilometer > Fuelamount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                travelledDistance += distance;
                fuelAmount -= distance * fuelConsumptionPerKilometer;
            }
        }
    }
}
