using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();

            //models.Add(new SpaceForces());
            //models.Add(new AnonymousImpactUnit());
            //models.Add(new StormTroopers());


        }

        public IReadOnlyCollection<IMilitaryUnit> Models => models;
        public void AddItem(IMilitaryUnit model)
        {
             models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return models.FirstOrDefault(m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {

            return models.Remove(models.FirstOrDefault(m => m.GetType().Name == name));
        }
    }
}
