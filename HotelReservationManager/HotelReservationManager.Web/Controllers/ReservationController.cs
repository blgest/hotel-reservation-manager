using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using HotelReservationManager.ViewModels.ReservationViewModels;
using HotelReservationManager.ViewModels.RoomViewModels;
using HotelReservationManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IClientService clientService;
        private readonly IRoomService roomService;
        private readonly IHotelUserService hotelUserService;
        private readonly List<ReservationViewModel> reservations;

        public ReservationController(IReservationService reservationService, IClientService clientService,
            IRoomService roomService, IHotelUserService hotelUserService)
        {
            this.reservationService = reservationService;
            this.clientService = clientService;
            this.roomService = roomService;
            this.hotelUserService = hotelUserService;
            this.reservations = reservationService.GetAll();
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createReservationViewModel = new CreateReservationViewModel();
            return this.View(createReservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationViewModel createReservationViewModel)
        {
            createReservationViewModel.User = this.hotelUserService.GetDataModelById(createReservationViewModel.Id);
            createReservationViewModel.Room = this.roomService.GetDataModelById(createReservationViewModel.RoomId);

            this.reservationService.Create(createReservationViewModel);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List(string currentFilter, string searchString, int? pageNumber)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var foundReservations = this.reservations;

            DateTime date;

            if (DateTime.TryParse(searchString, out date))
            {
                foundReservations = reservations
                    .Where(x => x.StartDate == date
                    || x.EndDate == date)
                    .ToList();
            }

            int pageSize = 5;
            return View(PaginatedList<ReservationViewModel>.Create(foundReservations, pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(string id)
        {
            var reservation = this.reservationService.GetDataModelById(id);

            var adults = new List<Client>();
            var childrens = new List<Client>();

            foreach (var clientReservation in reservation.ClientsReservations)
            {
                var client = this.clientService.GetDataModelById(clientReservation.ClientId);

                if (client.IsAdult == true)
                {
                    adults.Add(client);
                }
                else
                {
                    childrens.Add(client);
                }
            }

            var detailsViewModel = new ReservationDetailsViewModel(reservation.Id, reservation.User, reservation.StartDate,
                reservation.EndDate, adults, childrens, reservation.Room, reservation.Breakfast, reservation.AllInclusive,
                reservation.Price);

            return this.View(detailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var reservation = this.reservationService.GetDataModelById(id);

            var editReservation = new EditReservationViewModel(reservation.Id, reservation.StartDate,
                reservation.EndDate, reservation.AdultsCount, reservation.ChildrensCount, reservation.RoomType,
                reservation.Room, reservation.Breakfast, reservation.AllInclusive, reservation.Price, this.roomService.GetAll());

            return this.View(editReservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, DateTime startDate, DateTime endDate, int adultsCount,
            int childrensCount, RoomType roomType, string rooms, bool breakfast, bool allInclusive, double price)
        {
            var room = this.roomService.GetDataModelById(rooms);

            this.reservationService.Edit(id, startDate, endDate, adultsCount, childrensCount, roomType, room, breakfast,
                allInclusive, price);

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(string id)
        {
            this.reservationService.Delete(id);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> AddClients(string id)
        {
            var reservation = this.reservationService.GetDataModelById(id);

            var addClientsViewModel = new AddClientsViewModel(id, reservation.AdultsCount, reservation.ChildrensCount);

            addClientsViewModel.Adults = this.clientService
                .GetAll()
                .Where(x => x.IsAdult == true)
                .ToList();

            addClientsViewModel.Childrens = this.clientService
               .GetAll()
               .Where(x => x.IsAdult == false)
               .ToList();

            return this.View(addClientsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddClients(string id, List<string> adults, List<string> childrens)
        {
            var clients = new List<Client>();

            foreach (var adultId in adults)
            {
                var adult = this.clientService.GetDataModelById(adultId);
                clients.Add(adult);
            }

            foreach (var childrenId in childrens)
            {
                var children = this.clientService.GetDataModelById(childrenId);
                clients.Add(children);
            }

            this.reservationService.AddClients(clients, id);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public JsonResult FiltrateRooms(DateTime startDate, DateTime endDate, int adultsCount, int childrensCount, RoomType roomType)
        {
            var rooms = this.roomService.GetAllFreeRoomsByRequirments(startDate, endDate, childrensCount + adultsCount, roomType);
            
            return Json(rooms);
        }

        public JsonResult CalculatePrice(int adultsCount, int childrensCount, string roomId, DateTime startDate, DateTime endDate)
        {
            double price = 0.0;

            if (roomId != null)
            {
                var room = this.roomService.GetDataModelById(roomId);

                price = this.reservationService.CalculatePrice(adultsCount, childrensCount, room, startDate, endDate);
            }

            return Json(price);
        }
    }
}