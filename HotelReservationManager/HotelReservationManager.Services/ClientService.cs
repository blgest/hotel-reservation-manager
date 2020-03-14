using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationManager.Services
{
    public class ClientService : IClientService
    {
        private HotelReservationManagerDbContext dbContext;

        public ClientService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string firstName, string thirdName, string phoneNumber, string email, int years)
        {
            var newClient = new Client(
                Guid.NewGuid().ToString(),
                firstName,
                thirdName,
                phoneNumber,
                email,
                years > 18 ? true : false);

            this.dbContext.Clients.Add(newClient);
            this.dbContext.SaveChanges();
        }

        public void Delete(string clientId)
        {
            var client = GetById(clientId);

            foreach (var clientReservation in client.ClientsReservations)
            {
                var reservation = this.dbContext.Reservations.Find(clientReservation.ReservationId);
                reservation.ClientsReservations.Remove(clientReservation);
            }

            client.ClientsReservations = new List<ClientReservations>();

            this.dbContext.Clients.Remove(client);

            this.dbContext.SaveChanges();
        }

        public void Edit(string id, string firstName, string thirdName, string phoneNumber,
            string email, bool isAdult)
        {
            var client = GetById(id);

            client.FirstName = firstName;
            client.ThirdName = thirdName;
            client.Telephone = phoneNumber;
            client.Email = email;
            client.IsAdult = isAdult;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return this.dbContext.Clients
                .OrderBy(x=>x.FirstName)
                .ThenBy(x=>x.ThirdName);
        }

        public Client GetById(string id)
        {
            var clients = this.dbContext.Clients
                .Include(x => x.ClientsReservations).ToList();

            return clients.FirstOrDefault(x => x.Id == id);
        }
    }
}
