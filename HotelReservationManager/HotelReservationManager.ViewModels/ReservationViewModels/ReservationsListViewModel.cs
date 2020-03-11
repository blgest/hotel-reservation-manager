using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.ReservationViewModels
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
