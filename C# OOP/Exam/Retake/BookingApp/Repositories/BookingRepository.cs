using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        public BookingRepository()
        {
            
        }

        private List<IBooking> models = new List<IBooking>();
        public void AddNew(IBooking model)
        {
            models.Add(model);
        }

        public IBooking Select(string criteria)
        {
            return models.FirstOrDefault(m => m.BookingNumber.ToString() == criteria);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return models.AsReadOnly();
        }
    }
}
