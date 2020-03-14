using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class AddClientsViewModel
    {
        public AddClientsViewModel(string reservationId, int adultsCount, int childrensCount)
        {
            this.ReservationId = reservationId;
            this.AdultsCount = adultsCount;
            this.ChildrensCount = childrensCount;
        }

        public AddClientsViewModel()
        {

        }

        public string ReservationId { get; set; }

        public int AdultsCount { get; set; }

        public IEnumerable<Client> Adults{ get; set; }

        public int ChildrensCount { get; set; }

        public IEnumerable<Client> Childrens { get; set; }
    }
}
