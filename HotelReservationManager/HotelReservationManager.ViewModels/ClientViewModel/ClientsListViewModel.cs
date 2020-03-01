using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.ClientViewModels
{
    public class ClientsListViewModel
    {
        public ClientsListViewModel()
        {
            this.Clients = new List<ClientViewModel>();
        }

        public List<ClientViewModel> Clients { get; set; }
    }
}
