using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.UserViewModels
{
    public class BlockedUserViewModel
    {
        public BlockedUserViewModel(string id, string username, string firstName, string secondName, string thirdName, 
            string ucn, string phoneNumber, string email, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            UCN = ucn;
            PhoneNumber = phoneNumber;
            Email = email;
            StartDate = startDate;
            EndDate = endDate;
        }

        public BlockedUserViewModel(string id, string username, string firstName, string secondName, string thirdName, string ucn, 
            string phoneNumber, string email, DateTime startDate, DateTime endDate, string role) : this(id, username, firstName, secondName, 
                thirdName, ucn, phoneNumber, email, startDate, endDate)
        {
            Role = role;
        }

        public BlockedUserViewModel()
        {

        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string UCN { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Role { get; set; }
    }
}
