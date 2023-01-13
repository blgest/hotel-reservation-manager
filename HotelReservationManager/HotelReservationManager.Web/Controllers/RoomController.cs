using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using HotelReservationManager.ViewModels.RoomViewModels;
using HotelReservationManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace HotelReservationManager.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly List<RoomViewModel> rooms;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
            rooms = roomService.GetAll();
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
            this.roomService.Create(createRoomViewModel);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List(string currentFilter, string searchString, int? pageNumber)
        {
            var term = 0;

            if (searchString != null)
            {
                pageNumber = 1;
                term = int.Parse(searchString);
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var foundRooms = this.rooms;

            if (term > 0)
            {
                foundRooms = rooms
                    .Where(x => x.Number.ToString().Contains(term.ToString()) || x.Capacity >= term)
                    .ToList();
            }

            int pageSize = 5;
            return View(PaginatedList<RoomViewModel>.Create(foundRooms, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var room = this.rooms.FirstOrDefault(x => x.Id == id);

            if (room == null)
            {
                return this.RedirectToAction("List");
            }

            return this.View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomViewModel roomViewModel)
        {
            this.roomService.Edit(roomViewModel);

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(string id)
        {
            this.roomService.Delete(id);

            return this.RedirectToAction("List");
        }
    }
}