using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels;
using HotelReservationManager.ViewModels.ClientViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManager.Services
{
    public class ClientService : IClientService
    {
        private HotelReservationManagerDbContext dbContext;

        public ClientService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CreateClientViewModel createClientViewModel)
        {
            var newClient = new Client(
                Guid.NewGuid().ToString(),
                createClientViewModel.FirstName,
                createClientViewModel.ThirdName,
                createClientViewModel.PhoneNumber,
                createClientViewModel.Email,
                createClientViewModel.Years > 18 ? true : false);

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

            client.ClientsReservations.Clear();

            this.dbContext.Clients.Remove(client);
            this.dbContext.SaveChanges();
        }

        public void Edit(ClientViewModel clientViewModel)
        {
            var client = GetById(clientViewModel.Id);

            client.FirstName = clientViewModel.FirstName;
            client.ThirdName = clientViewModel.ThirdName;
            client.Telephone = clientViewModel.PhoneNumber;
            client.Email = client.Email;
            client.IsAdult = clientViewModel.IsAdult;

            this.dbContext.SaveChanges();
        }

        public List<ClientViewModel> GetAll()
        {
            return this.dbContext.Clients
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.ThirdName)
                .Select(x => ToClientViewModel(x))
                .ToList();
        }

        public Client GetById(string id)
        {
            return this.dbContext.Clients.FirstOrDefault(x => x.Id == id);
        }

        private static ClientViewModel ToClientViewModel(Client client)
        {
            return new ClientViewModel(client.Id, client.FirstName, client.ThirdName, client.Telephone, client.Email, client.IsAdult);
        }
    }
}
