using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();

            //models.Add(new BioChemicalWeapon());
        }

        public IReadOnlyCollection<IWeapon> Models => models;
        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {

            return models.Remove(models.FirstOrDefault(m => m.GetType().Name == name));
        }
    }
}
