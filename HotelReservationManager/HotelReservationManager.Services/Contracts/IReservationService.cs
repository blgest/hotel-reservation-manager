using HotelReservationManager.Data.Models;
using HotelReservationManager.ViewModels.ReservationViewModels;
using System;
using System.Collections.Generic;

namespace HotelReservationManager.Services.Contracts
{
    public interface IReservationService
    {
        void CheckForExpiredReservations();

        void Create(CreateReservationViewModel createReservationViewModel);

        double CalculatePrice(int childrensCount, int adultsCount, Room room, DateTime startDate, DateTime endDate);

        void Edit(string id, DateTime startDate, DateTime endDate, int adultsCount,
            int childrensCount, RoomType roomType, Room room, bool breakfast, bool allInclusive, double price);

        void Delete(string reservationId);

        void AddClients(List<Client> clients, string reservationId);

        List<ReservationViewModel> GetAll();

        Reservation GetDataModelById(string id);
    }
}
