using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Data.Models
{
    public class Client
    {
        public Client(string id, string firstName, string thirdName, string telephone, string email, bool isAdult)
        {
            Id = id;
            FirstName = firstName;
            ThirdName = thirdName;
            Telephone = telephone;
            Email = email;
            IsAdult = isAdult;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string ThirdName { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }

        public ICollection<ClientReservations> ClientsReservations { get; set; }
    }
}
