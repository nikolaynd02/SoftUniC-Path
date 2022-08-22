using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        public HotelRepository()
        {
            
        }

        private List<IHotel> models = new List<IHotel>();
        public void AddNew(IHotel model)
        {
            models.Add(model);
        }

        public IHotel Select(string criteria)
        {
            return models.FirstOrDefault(m => m.FullName == criteria);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return models.AsReadOnly();
        }
    }
}
