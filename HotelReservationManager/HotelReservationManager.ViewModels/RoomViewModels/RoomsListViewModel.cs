using HotelReservationManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.RoomViewModels
{
    public class RoomsListViewModel
    {
        public RoomsListViewModel()
        {
            this.Rooms = new List<RoomViewModel>();
        }

        public List<RoomViewModel> Rooms { get; set; }
    }
}
