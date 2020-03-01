using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Data.Models
{
    public class Room
    {
        public Room(string id, int capacity, RoomType type, bool isFree, double priceOnBedAdult, double priceOnBedChildren, int number)
        {
            Id = id;
            Capacity = capacity;
            Type = type;
            this.IsFree = isFree;
            PriceOnBedAdult = priceOnBedAdult;
            PriceOnBedChildren = priceOnBedChildren;
            Number = number;
        }

        public string Id { get; set; }

        public int Capacity { get; set; }

        public RoomType Type { get; set; }

        public bool IsFree { get; set; }

        public double PriceOnBedAdult { get; set; }

        public double PriceOnBedChildren { get; set; }

        public int Number { get; set; }
    }
}
