using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels;
using HotelReservationManager.ViewModels.RoomViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new CreateRoomViewModel();
            return this.View(createUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomViewModel createRoomViewModel)
        {

            this.roomService.Create(
                createRoomViewModel.Capacity,
                createRoomViewModel.Type,
                createRoomViewModel.PriceOnBedForAdult, createRoomViewModel.PriceOnBedForChildren,
                createRoomViewModel.Number);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = new RoomsListViewModel();
            TransferRoomsToViewModel(list.Rooms);
            return this.View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var room = this.roomService.GetById(id);

            var editClientViewModel = new RoomViewModel(room.Id, room.Capacity, room.Type, room.IsFree, room.PriceOnBedAdult,
                room.PriceOnBedChildren, room.Number);

            return this.View(editClientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomViewModel roomViewModel)
        {
            this.roomService.Edit(roomViewModel.Id, roomViewModel.Capacity, roomViewModel.Type, roomViewModel.PriceOnBedForAdult,
                roomViewModel.PriceOnBedForChildren, roomViewModel.Number);

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(string id)
        {
            this.roomService.Delete(id);

            return this.RedirectToAction("List");
        }


        private void TransferRoomsToViewModel(List<RoomViewModel> list)
        {
            foreach (var room in this.roomService.GetAll())
            {
                var roomViewModel = new RoomViewModel(room.Id, room.Capacity, room.Type, room.IsFree, room.PriceOnBedAdult,
                room.PriceOnBedChildren, room.Number);

                list.Add(roomViewModel);
            }
        }
    }
}