using HotelReservationManager.Data;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.RoomViewModels;
using Microsoft.EntityFrameworkCore;
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


        public void Create(CreateRoomViewModel  createRoomViewModel)
        {
            var newRoom = new Room(
                Guid.NewGuid().ToString(),
                createRoomViewModel.Capacity,
                createRoomViewModel.Type,
                true,
                createRoomViewModel.PriceOnBedForAdult,
                createRoomViewModel.PriceOnBedForChildren,
                createRoomViewModel.Number);

            this.dbContext.Rooms.Add(newRoom);
            this.dbContext.SaveChanges();
        }

        public void Delete(string roomId)
        {
            var room = GetDataModelById(roomId);

            foreach (var reservation in this.dbContext.Reservations.Include(x=>x.Room).Include(x=>x.ClientsReservations))
            {
                if (reservation.Room == room)
                {
                    foreach (var clientReservation in reservation.ClientsReservations)
                    {
                        var client = this.dbContext.Clients.Find(clientReservation.ClientId);

                        client.ClientsReservations = new List<ClientReservations>();
                    }

                    this.dbContext.Reservations.Remove(reservation);
                }
            }

            this.dbContext.Rooms.Remove(room);
            this.dbContext.SaveChanges();
        }

        public void Edit(RoomViewModel roomViewModel)
        {
            var room = GetDataModelById(roomViewModel.Id);

            room.Id = roomViewModel.Id;
            room.Capacity = roomViewModel.Capacity;
            room.Type = roomViewModel.Type;
            room.PriceOnBedAdult = roomViewModel.PriceOnBedForAdult;
            room.PriceOnBedChildren = roomViewModel.PriceOnBedForChildren;
            room.Number = roomViewModel.Number;

            this.dbContext.SaveChanges();
        }

        public List<RoomViewModel> GetAll()
        {
            return this.dbContext.Rooms
                .OrderBy(x => x.Number)
                .ThenBy(x => x.Type)
                .ThenBy(x => x.Capacity)
                .Select(x=>ToViewModel(x))
                .ToList();
        }

        public List<RoomViewModel> GetAllFreeRoomsByRequirments(DateTime startDate, DateTime endDate, int capacity, RoomType type)
        {
            var rooms = new List<RoomViewModel>();

            rooms = this.dbContext.Rooms
                .Where(r => r.Capacity >= capacity && r.Type == type)
                .Select(x=>ToViewModel(x))
                .ToList();

            foreach (var reservation in this.dbContext.Reservations)
            {
                if (startDate < reservation.StartDate)
                {
                    if (!CheckForPreviosDate(reservation.StartDate, startDate, endDate))
                    {
                        rooms.Remove(ToViewModel(reservation.Room));
                    }
                }
                else if (startDate > reservation.StartDate)
                {
                    if (!CheckForNextDate(startDate, reservation.StartDate, reservation.EndDate))
                    {
                        rooms.Remove(ToViewModel(reservation.Room));
                    }
                }
                else
                {
                    rooms.Remove(ToViewModel(reservation.Room));
                }
            }

            return rooms;
        }

        public Room GetDataModelById(string id)
        {
            return this.dbContext.Rooms.Find(id);
        }

        private bool CheckForNextDate(DateTime k, DateTime x, DateTime y)
        {
            return k > x && k >= y;
        }

        private bool CheckForPreviosDate(DateTime x, DateTime k, DateTime z)
        {
            return k < x && z <= x;
        }

        private static RoomViewModel ToViewModel(Room room)
        {
            return new RoomViewModel(room.Id, room.Capacity, room.Type, room.PriceOnBedAdult, room.PriceOnBedChildren, room.Number);
        }
    }
}
