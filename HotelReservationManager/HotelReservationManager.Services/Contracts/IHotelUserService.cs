using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services.Contracts
{
    public interface IHotelUserService
    {
        void Block(string hotelUserId);

        void Activate(string hotelUserId);

        void Edit(string id, string username, string firstName, string secondName,  string thirdName, string ucn, string phoneNumber, 
            string email, DateTime startDate, DateTime endDate);

        public IEnumerable<HotelUser> GetAllActive();

        public IEnumerable<HotelUser> GetAllBlocked();

        HotelUser GetById(string id);
    }
}
