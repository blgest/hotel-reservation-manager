using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ReservationViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace HotelReservationManager.Services
{
    public class ReservationService : IReservationService
    {
        private HotelReservationManagerDbContext dbContext;

        public ReservationService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CheckForExpiredReservations()
        {
            var reservations = this.dbContext.Reservations.Include(x => x.Room).ToList();

            foreach (var reservation in reservations)
            {
                var room = reservation.Room;

                if (DateTime.UtcNow >= reservation.EndDate)
                {
                    room.IsFree = true;
                }
            }

            this.dbContext.SaveChanges();
        }

        public double CalculatePrice(int childrensCount, int adultsCount, Room room, DateTime startDate, DateTime endDate)
        {
            var time = (endDate - startDate).TotalDays;

            return (childrensCount * room.PriceOnBedChildren + adultsCount * room.PriceOnBedAdult) * time;
        }

        public void Create(CreateReservationViewModel createReservationViewModel)
        {
            createReservationViewModel.Room.IsFree = false;

            var reservation = new Reservation()
            {
                Id = Guid.NewGuid().ToString(),
                Room = createReservationViewModel.Room,
                User = createReservationViewModel.User,
                RoomType = createReservationViewModel.RoomType,
                AdultsCount = createReservationViewModel.AdultsCount,
                ChildrensCount = createReservationViewModel.ChildrensCount,
                StartDate = createReservationViewModel.StartDate,
                EndDate = createReservationViewModel.EndDate,
                Breakfast = createReservationViewModel.Breakfast,
                AllInclusive = createReservationViewModel.AllInclusive,
                Price = createReservationViewModel.Price
            };

            this.dbContext.Add(reservation);

            this.dbContext.SaveChanges();
        }

        public void Delete(string reservationId)
        {
            var reservation = GetDataModelById(reservationId);

            RemoveClients(reservation);
            reservation.Room.IsFree = true;
            this.dbContext.Reservations.Remove(reservation);

            this.dbContext.SaveChanges();
        }

        public void Edit(string id, DateTime startDate, DateTime endDate, int adultsCount,
            int childrensCount, RoomType roomType, Room room, bool breakfast, bool allInclusive, double price)
        {
            var reservation = GetDataModelById(id);

            reservation.Room = room;
            reservation.StartDate = startDate;
            reservation.EndDate = endDate;
            if (reservation.AdultsCount != adultsCount || reservation.ChildrensCount != childrensCount)
            {
                reservation.AdultsCount = adultsCount;
                reservation.ChildrensCount = childrensCount;

                RemoveClients(reservation);
            }
            reservation.RoomType = roomType;
            reservation.Breakfast = breakfast;
            reservation.AllInclusive = allInclusive;
            reservation.Price = price;

            this.dbContext.SaveChanges();
        }

        public void AddClients(List<Client> clients, string reservationId)
        {
            var reservation = GetDataModelById(reservationId);

            foreach (var client in clients)
            {
                var clientReservations = new ClientReservations()
                {
                    ClientId = client.Id,
                    Client = client,
                    ReservationId = reservationId,
                    Reservation = reservation
                };

                client.ClientsReservations.Add(clientReservations);
                reservation.ClientsReservations.Add(clientReservations);
            }

            this.dbContext.SaveChanges();
        }

        public List<ReservationViewModel> GetAll()
        {
            return this.dbContext.Reservations
                .Include(x => x.Room)
                .Include(x => x.User)
                .Include(x => x.ClientsReservations)
                .OrderBy(x => x.StartDate)
                .ThenBy(x => x.EndDate)
                .Select(x => ToViewModel(x))
                .ToList();
        }

        public Reservation GetDataModelById(string id)
        {
            return this.dbContext.Reservations.FirstOrDefault(x=>x.Id == id);
        }

        private void RemoveClients(Reservation reservation)
        {
            foreach (var clientReservation in reservation.ClientsReservations)
            {
                var client = this.dbContext.Clients.Find(clientReservation.ClientId);

                client.ClientsReservations.Remove(clientReservation);
            }

            reservation.ClientsReservations = new List<ClientReservations>();
        }

        private static ReservationViewModel ToViewModel(Reservation reservation)
        {
            return new ReservationViewModel(reservation.Id, reservation.User, reservation.StartDate, reservation.EndDate,
                reservation.AdultsCount, reservation.ChildrensCount, reservation.RoomType, reservation.Room, reservation.Breakfast,
                reservation.AllInclusive, reservation.Price, reservation.ClientsReservations.Count);
        }
    }
}
