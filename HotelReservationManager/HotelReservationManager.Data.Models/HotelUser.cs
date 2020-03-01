using Microsoft.AspNetCore.Identity;
using System;


namespace HotelReservationManager.Data.Models
{
    public class HotelUser : IdentityUser<string>
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string UCN { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime EndDate { get; set; }
    }
}
