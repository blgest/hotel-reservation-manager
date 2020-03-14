using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.ClientViewModels
{
    public class CreateClientViewModel
    {
        [Required(ErrorMessage = "Must be entered some First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must be entered some Third Name")]
        public string ThirdName { get; set; }

        [Required(ErrorMessage = "Must be entered some Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Must be entered some Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must be entered true or false")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Years { get; set; }
    }
}

