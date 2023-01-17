using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.ClientViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel(string id, string firstName, string thirdName, 
            string phoneNumber, string email, DateTime birthdate)
        {
            Id = id;
            FirstName = firstName;
            LastName = thirdName;
            PhoneNumber = phoneNumber;
            Email = email;
            Birthdate = birthdate;
        }

        public ClientViewModel(string id, string firstName, string lastName,
           string phoneNumber, string email, DateTime birthdate, bool isAdult)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Birthdate = birthdate;
            IsAdult = isAdult;
        }

        public ClientViewModel()
        {

        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Must be entered some First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must be entered some Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must be entered some Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Must be entered some Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must be entered some Bithdate")]
        public DateTime Birthdate { get; set; }

        public bool IsAdult { get; set; }
    }
}
