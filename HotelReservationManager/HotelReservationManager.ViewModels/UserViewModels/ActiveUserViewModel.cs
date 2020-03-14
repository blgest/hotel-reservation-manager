using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.UserViewModels
{
    public class ActiveUserViewModel
    {
        public ActiveUserViewModel(string id, string username, string firstName, string secondName, string thirdName, 
            string ucn, string phoneNumber, string email, DateTime startDate)
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
        }

        public ActiveUserViewModel(string id, string username, string firstName, string secondName, string thirdName, string ucn, 
            string phoneNumber, string email, DateTime startDate, string role) : this(id, username, firstName, secondName, thirdName, ucn, 
                phoneNumber, email, startDate)
        {
            Role = role;
        }

        public ActiveUserViewModel()
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

        public string Role { get; set; }
    }
}
