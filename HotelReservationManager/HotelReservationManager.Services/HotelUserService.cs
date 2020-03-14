using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationManager.Services
{
    public class HotelUserService : IHotelUserService
    {
        private HotelReservationManagerDbContext dbContext;

        public HotelUserService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AreThereAnyUsers()
        {
            return this.dbContext.Users.Count() > 0;
        }

        public void Block(string hotelUserId)
        {
            var currUser = GetById(hotelUserId);

            currUser.IsActive = false;
            currUser.EndDate = DateTime.UtcNow;

            dbContext.SaveChanges();
        }

        public void Activate(string hotelUserId)
        {
            var currUser = GetById(hotelUserId);

            currUser.IsActive = true;

            currUser.StartDate = DateTime.Now;
            currUser.EndDate = default(DateTime);

            dbContext.SaveChanges();
        }


        public void Edit(string id, string username, string firstName, string secondName,
            string thirdName, string ucn, string phoneNumber, string email, DateTime startDate, DateTime endDate)
        {
            var hotelUser = GetById(id);

            hotelUser.UserName = username;
            hotelUser.FirstName = firstName;
            hotelUser.SecondName = secondName;
            hotelUser.ThirdName = thirdName;
            hotelUser.UCN = ucn;
            hotelUser.PhoneNumber = phoneNumber;
            hotelUser.Email = email;
            hotelUser.StartDate = startDate;
            hotelUser.EndDate = endDate;

            dbContext.SaveChanges();
        }

        public HotelUser GetCurrent(string concurrencyStamp)
        {
            var hotelUser = this.dbContext
                .Users
                .FirstOrDefault(x => x.ConcurrencyStamp == concurrencyStamp);

            return hotelUser;
        }

        public IEnumerable<HotelUser> GetAllActive()
        {
            var actives = this.dbContext
                .Users
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.UserName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.SecondName)
                .ThenBy(x => x.ThirdName)
                .ToList();

            return actives;
        }

        public IEnumerable<HotelUser> GetAllBlocked()
        {
            var blocked = this.dbContext
                 .Users
                 .Where(x => x.IsActive == false)
                 .OrderBy(x => x.UserName)
                 .ThenBy(x => x.FirstName)
                 .ThenBy(x => x.SecondName)
                 .ThenBy(x => x.ThirdName)
                 .ToList();

            return blocked;
        }

        public HotelUser GetById(string id)
        {
            return this.dbContext.Users.Find(id);
        }
    }
}
