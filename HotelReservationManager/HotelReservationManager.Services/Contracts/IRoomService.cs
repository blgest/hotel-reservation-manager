using HotelReservationManager.Data.Models;
using HotelReservationManager.ViewModels.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationManager.Services.Contracts
{
    public interface IRoomService
    {
        void Create(CreateRoomViewModel createRoomViewModel);

        void Delete(string roomId);

        void Edit(RoomViewModel roomViewModel);

        List<RoomViewModel> GetAll();

        List<RoomViewModel> GetAllFreeRoomsByRequirments(DateTime startDate, DateTime endDate, int capacity, RoomType type);

        Room GetDataModelById(string id);
    }
}
