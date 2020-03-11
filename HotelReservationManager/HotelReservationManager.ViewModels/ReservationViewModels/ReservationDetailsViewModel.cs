using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class ReservationDetailsViewModel
    {


        public ReservationDetailsViewModel()
        {

        }

        public ReservationDetailsViewModel(string id, HotelUser hotelUser, DateTime startDate, DateTime endDate, 
            List<Client> adults, List<Client> childrens, Room room, bool breakfast, bool allInclusive, double price)
        {
            Id = id;
            HotelUser = hotelUser;
            StartDate = startDate;
            EndDate = endDate;
            Adults = adults;
            Childrens = childrens;
            Room = room;
            Breakfast = breakfast;
            AllInclusive = allInclusive;
            Price = price;
        }

        public string Id { get; set; }

        public HotelUser HotelUser{ get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Client> Adults { get; set; }

        public List<Client> Childrens { get; set; }

        public Room Room { get; set; }

        public bool Breakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Price { get; set; }
    }
}
