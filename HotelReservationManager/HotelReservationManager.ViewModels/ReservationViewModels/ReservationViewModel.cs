using HotelReservationManager.Data.Models;
using System;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class ReservationViewModel
    {
        public ReservationViewModel(string id, string username, DateTime startDate, DateTime endDate, int adultsCount, int childrensCount,
            RoomType roomType, int roomNumber, bool breakfast, bool allInclusive, double price, int clientsReservationsCount)
        {
            Id = id;
            Username = username;
            StartDate = startDate;
            EndDate = endDate;
            AdultsCount = adultsCount;
            ChildrensCount = childrensCount;
            RoomType = roomType;
            RoomNumber = roomNumber;
            Breakfast = breakfast;
            AllInclusive = allInclusive;
            Price = price;
            ClientsReservationsCount = clientsReservationsCount;
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrensCount { get; set; }

        public RoomType RoomType { get; set; }

        public int RoomNumber { get; set; }

        public bool Breakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Price { get; set; }

        public int ClientsReservationsCount { get; set; }
    }
}
