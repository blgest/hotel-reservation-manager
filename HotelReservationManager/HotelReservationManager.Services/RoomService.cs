using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Edit(string id, int capacity, RoomType type, double priceOnBedAdult, double priceOnBedChildren, int number)
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

        public List<Room> GetAll()
        {
            return this.dbContext.Rooms.ToList();
        }

        public List<Room> GetAllFreeRoomsByRequirments(DateTime startDate, DateTime endDate, int capacity, RoomType type)
        {
            var rooms = new List<Room>();

            rooms = this.dbContext.Rooms
                .Where(r => r.Capacity >= capacity && r.Type == type)
                .ToList();

            foreach (var reservation in this.dbContext.Reservations)
            {
                if (startDate < reservation.StartDate)
                {
                    if (!CheckForPreviosDate(reservation.StartDate, startDate, endDate))
                    {
                        rooms.Remove(reservation.Room);
                    }
                }
                else if (startDate > reservation.StartDate)
                {
                    if (!CheckForNextDate(startDate, reservation.StartDate, reservation.EndDate))
                    {
                        rooms.Remove(reservation.Room);
                    }
                }
                else
                {
                    rooms.Remove(reservation.Room);
                }
            }

            return rooms;
        }

        private static bool CheckForNextDate(DateTime k, DateTime x, DateTime y)
        {
            return k > x && k >= y;
        }

        private static bool CheckForPreviosDate(DateTime x, DateTime k, DateTime z)
        {
            return k < x && z <= x;
        }


        public Room GetById(string id)
        {
            return this.dbContext.Rooms.Find(id);
        }
    }
}
