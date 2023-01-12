using HotelReservationManager.Data.Models;
using System.Collections.Generic;
using HotelReservationManager.ViewModels;
using HotelReservationManager.ViewModels.ClientViewModels;

namespace HotelReservationManager.Services.Contracts
{
    public interface IClientService
    {
        void Create(CreateClientViewModel createClientViewModel);

        void Delete(string clientId);

        void Edit(ClientViewModel clientViewModel);

        List<ClientViewModel> GetAll();

        Client GetById(string id);
    }
}
