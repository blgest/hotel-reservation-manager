using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.UserViewModels
{
    public class ActiveUsersListViewModel
    {
        public ActiveUsersListViewModel()
        {
            this.Users = new List<ActiveUserViewModel>();
        }

        public List<ActiveUserViewModel> Users { get; set; }
    }
}
