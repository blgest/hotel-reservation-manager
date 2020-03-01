using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.ViewModels.UserViewModels
{
    public class ActiveUserViewModel
    {
        public ActiveUserViewModel(string id, string username, string firstName, string secondName, string thirdName, 
            string uCN, string phoneNumber, string email, DateTime startDate)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            UCN = uCN;
            PhoneNumber = phoneNumber;
            Email = email;
            StartDate = startDate;
        }

        public ActiveUserViewModel()
        {

        }

        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string ThirdName { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
        public string UCN { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}
