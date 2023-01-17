using System;
using System.Linq;
using System.Collections.Generic;
using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;

namespace HotelReservationManager.Services
{
    public class ClientService : IClientService
    {
        private HotelReservationManagerDbContext dbContext;

        public ClientService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(ClientViewModel clientViewModel)
        {
            var newClient = new Client(
                Guid.NewGuid().ToString(),
                clientViewModel.FirstName,
                clientViewModel.LastName,
                clientViewModel.PhoneNumber,
                clientViewModel.Email,
                CalculateAge(clientViewModel.Birthdate) > 18 ? true : false,
                clientViewModel.Birthdate);

            this.dbContext.Clients.Add(newClient);
            this.dbContext.SaveChanges();
        }

        public void Delete(string clientId)
        {
            var client = GetDataModelById(clientId);

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
            var client = GetDataModelById(clientViewModel.Id);

            client.FirstName = clientViewModel.FirstName;
            client.LastName = clientViewModel.LastName;
            client.PhoneNumber = clientViewModel.PhoneNumber;
            client.Email = client.Email;
            client.Birthdate = clientViewModel.Birthdate;
            client.IsAdult = CalculateAge(clientViewModel.Birthdate) > 18 ? true : false;

            this.dbContext.SaveChanges();
        }

        public List<ClientViewModel> GetAll()
        {
            return this.dbContext.Clients
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => ToViewModel(x))
                .ToList();
        }

        public Client GetDataModelById(string id)
        {
            return this.dbContext.Clients.FirstOrDefault(x => x.Id == id);
        }

        private static ClientViewModel ToViewModel(Client client)
        {
            return new ClientViewModel(client.Id, client.FirstName, client.LastName, client.PhoneNumber, client.Email, client.Birthdate);
        }
        private int CalculateAge(DateTime birthdate)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
