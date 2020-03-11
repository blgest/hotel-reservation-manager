using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class ReservationViewModel
    {
        public ReservationViewModel(string id, HotelUser hotelUser, DateTime startDate, DateTime endDate, int adultsCount, 
            int childrensCount, RoomType roomType, Room room, bool breakfast, bool allInclusive, double price, List<Room> rooms)
        {
            Id = id;
            HotelUser = hotelUser;
            StartDate = startDate;
            EndDate = endDate;
            AdultsCount = adultsCount;
            ChildrensCount = childrensCount;
            RoomType = roomType;
            Room = room;
            Breakfast = breakfast;
            AllInclusive = allInclusive;
            Price = price;
            Rooms = rooms;
        }

        public ReservationViewModel(string id, HotelUser hotelUser, DateTime startDate, DateTime endDate, int adultsCount,
            int childrensCount, RoomType roomType, Room room, bool breakfast, bool allInclusive, double price, List<ClientReservations> clientsReservations)
        {
            Id = id;
            HotelUser = hotelUser;
            StartDate = startDate;
            EndDate = endDate;
            AdultsCount = adultsCount;
            ChildrensCount = childrensCount;
            RoomType = roomType;
            Room = room;
            Breakfast = breakfast;
            AllInclusive = allInclusive;
            Price = price;
            ClientsReservations = clientsReservations;
        }

        public ReservationViewModel()
        {

        }

        public string Id { get; set; }

        public HotelUser HotelUser { get; set; }

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

        public List<ClientReservations> ClientsReservations { get; set; }
    }
}
