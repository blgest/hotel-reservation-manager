using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services.Contracts
{
    public interface IRoomService
    {
        void Create(int capacity, RoomType type, double priceOnBedAdult, double priceOnBedChild, int number);

        void Delete(string roomId);

        void Edit(string id, int capacity, RoomType type, double priceOnBedAdult, double priceOnBedChildren, int number);

        IEnumerable<Room> GetAll();

        IEnumerable<Room> GetAllFreeRoomsByRequirments(DateTime startDate, DateTime endDate, int capacity, RoomType type);

        Room GetById(string id);
    }
}
