using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services.Contracts
{
    public interface IClientService
    {
        void Create(string firstName, string thirdName,string phoneNumber, string email, int years);

        void Delete(string clientId);

        void Edit(string id, string firstName, string thirdName, string phoneNumber,
            string email, bool isAdult);

        IEnumerable<Client> GetAll();

        Client GetById(string id);

        Client GetByEmail(string email);
    }
}
