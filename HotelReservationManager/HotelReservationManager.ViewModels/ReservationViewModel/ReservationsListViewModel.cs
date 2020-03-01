using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.ReservationViewModel
{
    public class ReservationsListViewModel
    {
        public ReservationsListViewModel()
        {
            this.Reservations = new List<ReservationViewModel>();
        }

        public List<ReservationViewModel> Reservations { get; set; }
    }
}
