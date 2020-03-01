using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services.Contracts
{
    public interface IReservationService
    {
        void Create(Room room, HotelUser hotelUser, IEnumerable<Client> clients, DateTime startDate, 
            DateTime endDate, bool breakfast, bool allInclusive);

        double CalculatePrice(IEnumerable<Client> clients, Room room, DateTime startDate, DateTime endDate);

        void Edit(string id, Room room, HotelUser hotelUser, IEnumerable<Client> clients, DateTime startDate,
            DateTime endDate, bool breakfast, bool allInclusive);

        void Delete(string reservationId);

        IEnumerable<Reservation> GetAll();

        Reservation GetById(string id);

        //delete reservatin when gone endDate
    }
}
