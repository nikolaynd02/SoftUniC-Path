using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        public RoomRepository()
        {
            
        }

        private readonly List<IRoom> models = new List<IRoom>();
        public void AddNew(IRoom model)
        {
            models.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return models.FirstOrDefault(m => m.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return models.AsReadOnly();
        }
    }
}
