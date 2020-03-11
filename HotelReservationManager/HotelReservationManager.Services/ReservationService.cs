using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Create(Room room, HotelUser hotelUser, int adultsCount, int childrensCount, DateTime startDate, DateTime endDate,
            bool breakfast, bool allInclusive, double price, RoomType roomType)
        {
            room.IsFree = false;

            var reservation = new Reservation()
            {
                Id = Guid.NewGuid().ToString(),
                Room = room,
                User = hotelUser,
                RoomType = roomType,
                AdultsCount = adultsCount,
                ChildrensCount = childrensCount,
                StartDate = startDate,
                EndDate = endDate,
                Breakfast = breakfast,
                AllInclusive = allInclusive,
                Price = price
            };

            this.dbContext.Add(reservation);

            this.dbContext.SaveChanges();
        }

        public void Delete(string reservationId)
        {
            var reservation = GetById(reservationId);

            RemoveClients(reservation);
            reservation.Room.IsFree = true;
            this.dbContext.Reservations.Remove(reservation);

            this.dbContext.SaveChanges();
        }

        public void Edit(string id, DateTime startDate, DateTime endDate, int adultsCount,
            int childrensCount, RoomType roomType, Room room, bool breakfast, bool allInclusive, double price)
        {
            var reservation = GetById(id);

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

            this.dbContext.SaveChanges();
        }

        public void AddClients(List<Client> clients, string reservationId)
        {
            var reservation = GetById(reservationId);

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

        private void RemoveClients(Reservation reservation)
        {
            foreach (var clientReservations in reservation.ClientsReservations)
            {
                var client = this.dbContext.Clients.Find(clientReservations.ClientId);

                client.ClientsReservations.Remove(clientReservations);
            }
            reservation.ClientsReservations = new List<ClientReservations>();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return this.dbContext.Reservations
                .Include(x => x.Room)
                .Include(x => x.User)
                .Include(x => x.ClientsReservations)
                .ToList();
        }

        public Reservation GetById(string id)
        {
            var reservations = this.dbContext.Reservations
                .Include(x => x.User)
                .Include(x => x.Room)
                .Include(x => x.ClientsReservations)
                .ToList();

            return reservations.FirstOrDefault(x => x.Id == id);
        }
    }
}
