using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit

    {
        private double cost;
        private int enduranceLevel = 1;


        public MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public double Cost
        {
            get { return this.cost; }

            private set { this.cost = value; }
        }
        public int EnduranceLevel => this.enduranceLevel;

        public void IncreaseEndurance()
        {
            this.enduranceLevel += 1;
            if (this.enduranceLevel > 20)
            {
                this.enduranceLevel = 20;

                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
