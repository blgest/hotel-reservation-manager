using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HotelReservationManager.Services
{
    public class HotelUserService : IHotelUserService
    {
        private HotelReservationManagerDbContext dbContext;

        public HotelUserService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public IEnumerable<HotelUser> GetAllActive()
        {
            var actives = this.dbContext
                .Users
                .Where(x => x.IsActive == true)
                .ToList();

            return actives;
        }

        public IEnumerable<HotelUser> GetAllBlocked()
        {
            var blocked = this.dbContext
                 .Users
                 .Where(x => x.IsActive == false)
                 .ToList();

            return blocked;
        }

        public HotelUser GetById(string id)
        {
            return this.dbContext.Users.Find(id);
        }

        private string GetHashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
