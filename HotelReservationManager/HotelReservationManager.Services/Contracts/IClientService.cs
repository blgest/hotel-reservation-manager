using HotelReservationManager.Data.Models;
using System.Collections.Generic;
using HotelReservationManager.ViewModels;
using HotelReservationManager.ViewModels.ClientViewModels;
using System.Threading.Tasks;
using System.Linq;

namespace HotelReservationManager.Services.Contracts
{
    public interface IClientService
    {
        void Create(ClientViewModel clientViewModel);

        void Delete(string clientId);

        void Edit(ClientViewModel clientViewModel);

        List<ClientViewModel> GetAll();

        Client GetDataModelById(string id);
    }
}
