using HotelReservationManager.Data.Models;
using HotelReservationManager.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services.Contracts
{
    public interface IHotelUserService
    {
        bool AreThereAnyUsers();

        void Block(string hotelUserId);

        void Activate(string hotelUserId);

        void Edit(UserViewModel user);

        HotelUser GetCurrent(string concurrencyStamp);

        public List<UserViewModel> GetAll();

        HotelUser GetDataModelById(string id);
    }
}
