using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.ViewModels.ClientViewModels
{
    public class CreateClientViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string ThirdName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Years { get; set; }
    }
}

