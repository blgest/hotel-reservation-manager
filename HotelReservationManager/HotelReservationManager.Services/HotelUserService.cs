using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationManager.Services
{
    public class HotelUserService : IHotelUserService
    {
        private HotelReservationManagerDbContext dbContext;
        private static UserManager<HotelUser> userManager;
        public HotelUserService(HotelReservationManagerDbContext dbContext, UserManager<HotelUser> userManager)
        {
            this.dbContext = dbContext;
            HotelUserService.userManager = userManager;
        }

        public bool AreThereAnyUsers()
        {
            return this.dbContext.Users.Count() > 0;
        }

        public void Block(string hotelUserId)
        {
            var currUser = GetDataModelById(hotelUserId);

            currUser.IsActive = false;
            currUser.EndDate = DateTime.UtcNow;

            dbContext.SaveChanges();
        }

        public void Activate(string hotelUserId)
        {
            var currUser = GetDataModelById(hotelUserId);

            currUser.IsActive = true;

            currUser.StartDate = DateTime.Now;
            currUser.EndDate = default(DateTime);

            dbContext.SaveChanges();
        }


        public void Edit(UserViewModel user)
        {
            var hotelUser = GetDataModelById(user.Id);

            hotelUser.UserName = user.Username;
            hotelUser.FirstName = user.FirstName;
            hotelUser.SecondName = user.SecondName;
            hotelUser.ThirdName = user.ThirdName;
            hotelUser.UCN = user.UCN;
            hotelUser.PhoneNumber = user.PhoneNumber;
            hotelUser.Email = user.Email;
            hotelUser.StartDate = user.StartDate;
            hotelUser.EndDate = user.EndDate;

            dbContext.SaveChanges();
        }

        public HotelUser GetCurrent(string concurrencyStamp)
        {
            var hotelUser = this.dbContext
                .Users
                .FirstOrDefault(x => x.ConcurrencyStamp == concurrencyStamp);

            return hotelUser;
        }

        public List<UserViewModel> GetAll()
        {
            return this.dbContext
                .Users
                .OrderBy(x => x.UserName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.SecondName)
                .ThenBy(x => x.ThirdName)
                .Select(x => ToViewModel(x))
                .ToList();
        }

        public HotelUser GetDataModelById(string id)
        {
            return this.dbContext.Users.Find(id);
        }

        private static UserViewModel ToViewModel(HotelUser hotelUser)
        {
            var role = userManager.GetRolesAsync(hotelUser).Result[0];

            UserViewModel userViewModel = new UserViewModel(hotelUser.Id, hotelUser.UserName, hotelUser.SecondName, hotelUser.SecondName,
                hotelUser.ThirdName, hotelUser.UCN, hotelUser.PhoneNumber, hotelUser.Email, hotelUser.StartDate, hotelUser.EndDate, role);
            return userViewModel;
        }
    }
}
