using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight = 0;
        private int bedCapacity;

        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity
        {
            get { return bedCapacity; }
            private set { bedCapacity = value; }
        }

        public double PricePerNight
        {
            get { return pricePerNight; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                pricePerNight = value;
            }
        }
        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
