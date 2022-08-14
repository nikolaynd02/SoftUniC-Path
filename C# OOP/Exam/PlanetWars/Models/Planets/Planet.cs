using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            units = new UnitRepository();
            weapons = new WeaponRepository();

            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get { return this.budget; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double power = this.units.Models.Sum(u => u.EnduranceLevel) + this.weapons.Models.Sum(w => w.DestructionLevel);

                if (units.Models.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
                {
                    power += (power * 30 / 100);
                }

                if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    power += (power * 45 / 100);
                }

                return Math.Round(power, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.budget < amount)
            {
                throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
            }

            this.budget -= amount;
        }

        public void Profit(double amount)
        {
            this.budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Planet: {this.name}");
            output.AppendLine($"--Budget: {this.budget} billion QUID");
            if (units.Models.Count > 0)
            {
                output.AppendLine($"Forces: {string.Join(", ", this.units.Models.Select(u => u.GetType().Name))}");
            }
            else
            {
                output.AppendLine($"Forces: No units");
            }

            if (weapons.Models.Count > 0)
            {
                output.AppendLine($"Combat equipment: {string.Join(", ", weapons.Models.Select(w => w.GetType().Name))}");
            }
            else
            {
                output.AppendLine($"Combat equipment: No weapons");
            }

            output.AppendLine($"--Military Power: {MilitaryPower}");

            return output.ToString().Trim();
        }
    }
}
