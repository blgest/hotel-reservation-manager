﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.ViewModels.ClientViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel(string id, string firstName, string thirdName, 
            string phoneNumber, string email, bool isAdult)
        {
            Id = id;
            FirstName = firstName;
            ThirdName = thirdName;
            PhoneNumber = phoneNumber;
            Email = email;
            IsAdult = isAdult;
        }

        public ClientViewModel()
        {

        }

        public string Id { get; set; }

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
        public bool IsAdult { get; set; }
    }
}
