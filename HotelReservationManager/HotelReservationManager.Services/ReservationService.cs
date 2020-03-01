using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services
{
    public class ReservationService : IReservationService
    {
        private HotelReservationManagerDbContext dbContext;

        public ReservationService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
            ReservationsEnd();
        }

        public double CalculatePrice(IEnumerable<Client> clients, Room room, DateTime startDate, DateTime endDate)
        {
            var childrensCount = 0;
            var adultsCount = 0;

            foreach (var client in clients)
            {
                if (client.IsAdult)
                {
                    adultsCount++;
                }
                else
                {
                    childrensCount++;
                }
            }

            var time = (endDate - startDate).TotalDays;

            return (childrensCount * room.PriceOnBedChildren + adultsCount * room.PriceOnBedAdult) * time;
        }

        public void Create(Room room, HotelUser hotelUser, IEnumerable<Client> clients, DateTime startDate, DateTime endDate, bool breakfast, bool allInclusive)
        {
            var reservation = new Reservation()
            {
                Id = Guid.NewGuid().ToString(),
                Room = room,
                User = hotelUser,
                StartDate = startDate,
                EndDate = endDate,
                Breakfast = breakfast,
                AllInclusive = allInclusive,
                Price = CalculatePrice(clients, room, startDate, endDate)
            };

            AddClientReservations(clients, reservation);

            this.dbContext.SaveChanges();
        }

        public void Delete(string reservationId)
        {
            var reservation = this.dbContext.Reservations.Find(reservationId);
            this.dbContext.Reservations.Remove(reservation);
            var clientReservation = dbContext.ClientReservations.Find(reservationId);
            dbContext.ClientReservations.Remove(clientReservation);
            this.dbContext.SaveChanges();
        }

        public void Edit(string id, Room room, HotelUser hotelUser, IEnumerable<Client> clients, DateTime startDate,
            DateTime endDate, bool breakfast, bool allInclusive)
        {
            var reservation = GetById(id);
            reservation.Room = room;
            reservation.User = hotelUser;
            EditClientReservation(clients, reservation);
            reservation.StartDate = startDate;
            reservation.EndDate = endDate;
            reservation.Breakfast = breakfast;
            reservation.AllInclusive = allInclusive;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return this.dbContext.Reservations;
        }

        public Reservation GetById(string id)
        {
            return this.dbContext.Reservations.Find(id);
        }

        private void ReservationsEnd()
        {
            foreach (var reservation in this.dbContext.Reservations)
            {
                var room = reservation.Room;

                if (DateTime.UtcNow > reservation.EndDate)
                {
                    room.IsFree = true;
                }
            }

        }

        private void AddClientReservations(IEnumerable<Client> clients, Reservation reservation)
        {
            foreach (var client in clients)
            {
                var clientReservations = new ClientReservations();
                clientReservations.ClientId = client.Id;
                clientReservations.ReservationId = reservation.Id;
                reservation.ClientsReservations.Add(clientReservations);
                client.ClientsReservations.Add(clientReservations);
            }
        }

        private void EditClientReservation(IEnumerable<Client> clients, Reservation reservation)
        {
            foreach (var client in clients)
            {
                var clientReservations = this.dbContext.ClientReservations;
                foreach (var clientReservation in clientReservations)
                {
                    clientReservation.ClientId = client.Id;
                }
            }
        }
    }
}
