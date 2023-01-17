using System;
using System.Collections.Generic;
namespace HotelReservationManager.Data.Models
{
    public class Client
    {
        public Client(string id, string firstName, string lastName, string phoneNumber, string email, bool isAdult, DateTime birthdate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            IsAdult = isAdult;
            Birthdate = birthdate;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }

        public DateTime Birthdate { get; set; }

        public virtual ICollection<ClientReservations> ClientsReservations { get; set; }
    }
}
