using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string id, string username, string firstName, string secondName, string thirdName,
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

        public UserViewModel(string id, string username, string firstName, string secondName, string thirdName, string ucn,
            string phoneNumber, string email, DateTime startDate, DateTime endDate, string role) : this(id, username, firstName, secondName,
                thirdName, ucn, phoneNumber, email, startDate, endDate)
        {
            Role = role;
        }

        public UserViewModel()
        {

        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Must be entered some Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Must be entered some First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must be entered some Second Name")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Must be entered some Third Name")]
        public string ThirdName { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
        public string UCN { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Must be entered some Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must be entered some Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Must be entered some Date")]
        public DateTime EndDate { get; set; }

        public string Role { get; set; }
    }
}
