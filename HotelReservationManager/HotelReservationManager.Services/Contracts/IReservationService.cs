using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services.Contracts
{
    public interface IReservationService
    {
        void CheckForExpiredReservations();

        void Create(Room room, HotelUser hotelUser, int adultsCount, int childrensCount, DateTime startDate, DateTime endDate,
            bool breakfast, bool allInclusive, double price, RoomType roomType);

        double CalculatePrice(int childrensCount, int adultsCount, Room room, DateTime startDate, DateTime endDate);

        void Edit(string id, DateTime startDate, DateTime endDate, int adultsCount, int childrensCount,
            RoomType roomType, Room room, bool breakfast, bool allInclusive, double price);

        void Delete(string reservationId);

        void AddClients(List<Client> clients, string reservationId);

        IEnumerable<Reservation> GetAll();

        Reservation GetById(string id);
    }
}
