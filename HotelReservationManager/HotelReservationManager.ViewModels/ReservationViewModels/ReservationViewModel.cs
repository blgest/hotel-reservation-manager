using HotelReservationManager.Data.Models;
using HotelReservationManager.ViewModels.RoomViewModels;
using System;
using System.Collections.Generic;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class ReservationViewModel
    {
        public ReservationViewModel(string id, HotelUser user, DateTime startDate, DateTime endDate,
            int adultsCount, int childrensCount, RoomType roomType, Room room, bool breakfast, bool allInclusive,
            double price, int clientsReservationsCount)
        {
            Id = id;
            User = user;
            StartDate = startDate;
            EndDate = endDate;
            AdultsCount = adultsCount;
            ChildrensCount = childrensCount;
            RoomType = roomType;
            Room = room;
            Breakfast = breakfast;
            AllInclusive = allInclusive;
            Price = price;
            ClientsReservationsCount = clientsReservationsCount;
        }

        public ReservationViewModel()
        {

        }

        public string Id { get; set; }
        public HotelUser User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrensCount { get; set; }

        public RoomType RoomType { get; set; }

        public List<Room> Rooms { get; set; }

        public Room Room { get; set; }
        public bool Breakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Price { get; set; }

        public int ClientsReservationsCount { get; set; }
    }
}
