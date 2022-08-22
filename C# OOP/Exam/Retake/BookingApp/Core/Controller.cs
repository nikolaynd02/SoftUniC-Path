using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private BookingRepository bookingRepository = new BookingRepository();
        private HotelRepository hotelRepository = new HotelRepository();
        private RoomRepository roomRepository = new RoomRepository();

        public Controller()
        {
            
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel exist = hotelRepository.Select(hotelName);

            if (exist != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            IHotel hotel = new Hotel(hotelName, category);

            hotelRepository.AddNew(hotel);

            return
                $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);


            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if(room != null)
            {
                return $"Room type is already created!";
            }

            IRoom newRoom;
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException("Incorrect room type!");
            }
            else if (roomTypeName == "Apartment")
            {
                newRoom = new Apartment();
            }
            else if(roomTypeName == "DoubleBed")
            {
                newRoom = new DoubleBed();
            }
            else
            {
                newRoom = new Studio();
            }

            hotel.Rooms.AddNew(newRoom);
            roomRepository.AddNew(newRoom);

            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotelRepository.Select(hotelName);
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException("Incorrect room type!");
            }

            if (room == null)
            {
                return $"Room type is not created yet!";
            }

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException($"Price is already set!");
            }

            room.SetPrice(price);

            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";

        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotels = hotelRepository.All().Where(h =>h.Category == category).OrderBy(h => h.FullName).ToList();

            if (orderedHotels.ToList().Count == 0)
            {
                return $"{category} star hotel is not available in our platform.";
            }

            List<IRoom> roomsWithPrice = new List<IRoom>();

            bool booked = false;
            IRoom bookedRoom;
            IBooking booking;

            int bookingNumber = 0;
            string hotelName = string.Empty;

            foreach (var hotel in orderedHotels)
            {
                foreach (var room in hotel.Rooms.All().Where(r => r.BedCapacity >= adults + children && r.PricePerNight > 0).OrderBy(r => r.BedCapacity))
                {
                    bookingNumber = hotel.Bookings.All().Count;

                    booked = true;
                    bookedRoom = room;
                    booking = new Booking(bookedRoom, duration, adults, children, bookingNumber + 1);
                    hotel.Bookings.AddNew(booking);
                    bookingRepository.AddNew(booking);

                    hotelName = hotel.FullName;

                    break;
                }

                if (booked == true)
                {
                    break;
                }
            }

            

            if (booked == false)
            {
                return "We cannot offer appropriate room for your request.";
            }


            return $"Booking number {bookingNumber} for {hotelName} hotel is successful!";


        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            StringBuilder output = new StringBuilder();

            output.AppendLine($"Hotel name: {hotelName}");
            output.AppendLine($"--{hotel.Category} star hotel");
            output.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            output.AppendLine("--Bookings:");
            output.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                output.AppendLine("none");
            }

            foreach (var booking in hotel.Bookings.All())
            {
                output.AppendLine(booking.BookingSummary());
                output.AppendLine();
            }

            return output.ToString().Trim();

        }
    }
}
