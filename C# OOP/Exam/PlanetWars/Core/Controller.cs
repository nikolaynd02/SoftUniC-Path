using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly PlanetRepository planetRepository;
        private readonly UnitRepository unitRepository;
        private readonly WeaponRepository weaponRepository;

        public Controller()
        {
            this.planetRepository = new PlanetRepository();
            this.unitRepository = new UnitRepository();
            this.weaponRepository = new WeaponRepository();
        }

        public string CreatePlanet(string planetName, double budget)
        {
            IPlanet planet = new Planet(planetName, budget);

            if (planetRepository.FindByName(planetName) != null)
            {
                return $"Planet {planetName} is already added!";
            }
            
            planetRepository.AddItem(planet);

            return $"Successfully added Planet: {planetName}";
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit unit = null;
            switch (unitTypeName)
            {
                case nameof(StormTroopers):
                    unit = new StormTroopers();
                    break;
                case nameof(SpaceForces):
                    unit = new SpaceForces();
                    break;
                case nameof(AnonymousImpactUnit):
                    unit = new AnonymousImpactUnit();
                    break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);


        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planetRepository.FindByName(planetName);
            

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            IWeapon weapon = null;

            switch (weaponTypeName)
            {
                case nameof(BioChemicalWeapon):
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case nameof(NuclearWeapon):
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case nameof(SpaceMissiles):
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = (Planet)planetRepository.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException($"No units available for upgrade!");
            }

            
            planet.TrainArmy();
            planet.Spend(1.25);

            return $"{planetName} has upgraded its forces!";

        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var attacker = planetRepository.FindByName(planetOne);
            var defender = planetRepository.FindByName(planetTwo);

            bool attackerIsNuclear = attacker.Weapons.Any(w => w is NuclearWeapon);
            bool defenderIsNuclear = defender.Weapons.Any(w => w is NuclearWeapon);
            IPlanet winner = null;
            IPlanet looser = null;
            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                winner = attacker;
                looser = defender;
            }
            else if (defender.MilitaryPower > attacker.MilitaryPower)
            {
                winner = defender;
                looser = attacker;
            }
            else
            {
                if (attackerIsNuclear && !defenderIsNuclear)
                {
                    winner = attacker;
                    looser = defender;
                }
                else if (defenderIsNuclear && !attackerIsNuclear)
                {
                    winner = defender;
                    looser = attacker;
                }
                else
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(u => u.Cost) + looser.Weapons.Sum(w => w.Price));

            planetRepository.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);

        }

        public string ForcesReport()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planetRepository.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                output.AppendLine(planet.PlanetInfo());
            }

            return output.ToString().Trim();
        }
    }
}
