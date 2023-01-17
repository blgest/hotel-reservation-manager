using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Data.Models
{
    public class Reservation
    {
        public string Id { get; set; }

        public virtual Room Room { get; set; }

        public virtual HotelUser User { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrensCount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RoomType RoomType { get; set; }

        public bool Breakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Price { get; set; }

        public virtual ICollection<ClientReservations> ClientsReservations { get; set; }
    }
}
