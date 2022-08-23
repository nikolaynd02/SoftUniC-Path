using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [Test]
        public void Booking_With_Valid_Constructor_Values()
        {

            var room = new Room(5, 100);

            var booking = new Booking(1, room, 10);

            Assert.AreEqual(5, room.BedCapacity);

            Assert.AreEqual(100, room.PricePerNight);

            Assert.AreEqual(1, booking.BookingNumber);

            Assert.AreEqual(10, booking.ResidenceDuration);
        }

        [Test]
        public void Hotel_Constructor_WIth_Valid_Values()
        {

            var hotel = new Hotel("GoldenSands", 4);

            Assert.AreEqual("GoldenSands", hotel.FullName);

            Assert.AreEqual(4, hotel.Category);


        }

        [Test]
        public void Invalid_FullName_ForHotel()
        {
            Assert.Throws<ArgumentNullException>((() => new Hotel(null, 3)));
        }

        [Test]
        public void Invalid_FullName_For_Hotel_White_Space()
        {
            Assert.Throws<ArgumentNullException>((() => new Hotel("", 3)));
        }

        [Test]
        public void Invalid_Values_For_Category()
        {
            Assert.Throws<ArgumentException>((() => new Hotel("GoldenSands", 6)));
            Assert.Throws<ArgumentException>((() => new Hotel("GoldenSands", 0)));
        }

        [Test]
        public void Increase_The_Room_Counter()
        {
            var hotel = new Hotel("GoldenSands", 4);

            var room = new Room(2, 50);

            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void Invalid_Values_For_Book_Room_Adults()
        {
            var hotel = new Hotel("MiraMar", 4);

            Assert.Throws<ArgumentException>((() => hotel.BookRoom(0, 10, 10, 10)));
        }

        [Test]
        public void Invalid_Values_For_Book_For_Kids()
        {
            var hotel = new Hotel("GoldenSands", 4);

            Assert.Throws<ArgumentException>((() => hotel.BookRoom(1, -2, 10, 10)));
        }

        [Test]
        public void Invalid_Values_For_Book_For_Residence_Duration()
        {
            var hotel = new Hotel("GoldenSands", 4);



            Assert.Throws<ArgumentException>((() => hotel.BookRoom(3, 7, -1, 10)));

        }

        [Test]
        public void Book_Room_With_Valid_Values()
        {

            var hotel = new Hotel("GoldenSands", 4);

            var room = new Room(10, 10);

            hotel.AddRoom(room);

            hotel.BookRoom(1, 1, 10, 1000);

            Assert.AreEqual(1, hotel.Bookings.Count);

            Assert.AreEqual(100, hotel.Turnover);

        }

        [Test]
        public void Room_Constructor_With_Valid_Values()
        {

            var room = new Room(4, 60);

            Assert.AreEqual(60, room.PricePerNight);

            Assert.AreEqual(4, room.BedCapacity);
        }

        [Test]
        public void Bed_Capacity_With_Invalid_Values()
        {
            Assert.Throws<ArgumentException>((() => new Room(0, 10)));
            Assert.Throws<ArgumentException>((() => new Room(10, 0)));
        }

    }
}