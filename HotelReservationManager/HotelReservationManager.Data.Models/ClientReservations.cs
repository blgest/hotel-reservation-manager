using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Data.Models
{
    public class ClientReservations
    {
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public string ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
