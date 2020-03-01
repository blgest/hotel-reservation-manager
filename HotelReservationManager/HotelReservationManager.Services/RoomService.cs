using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services
{
    public class RoomService : IRoomService
    {
        private HotelReservationManagerDbContext dbContext;

        public RoomService(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Create(int capacity, RoomType type, double priceOnBedAdult, double priceOnBedChildren, int number)
        {
            var newRoom = new Room(
                Guid.NewGuid().ToString(), 
                capacity, 
                type,
                true, 
                priceOnBedAdult, 
                priceOnBedChildren, 
                number);

            this.dbContext.Rooms.Add(newRoom);
            this.dbContext.SaveChanges();
        }

        public void Delete(string roomId)
        {
            var room = GetById(roomId);

            this.dbContext.Rooms.Remove(room);
            this.dbContext.SaveChanges();
        }

        public void Edit(string id, int capacity, RoomType type, double priceOnBedAdult, 
            double priceOnBedChildren, int number)
        {
            var room = GetById(id);

            room.Id = id;
            room.Capacity = capacity;
            room.Type = type;
            room.PriceOnBedAdult = priceOnBedAdult;
            room.PriceOnBedChildren = priceOnBedChildren;
            room.Number = number;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return this.dbContext.Rooms;
        }

        public Room GetById(string id)
        {
            return this.dbContext.Rooms.Find(id);
        }
    }
}
