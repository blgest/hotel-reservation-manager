using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.UserViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Must be entered some Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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
    }
}

