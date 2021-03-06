﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ReservationViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        private readonly IClientService clientService;

        private readonly IRoomService roomService;

        private readonly IHotelUserService hotelUserService;

        public ReservationController(IReservationService reservationService, IClientService clientService,
            IRoomService roomService, IHotelUserService hotelUserService)
        {
            this.reservationService = reservationService;
            this.clientService = clientService;
            this.roomService = roomService;
            this.hotelUserService = hotelUserService;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createReservationViewModel = new CreateReservationViewModel();
            return this.View(createReservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string id, int adultsCount, int childrensCount, DateTime startDate,
            DateTime endDate, RoomType roomType, string rooms, bool breakfast, bool allInclusive, double price)
        {
            var hotelUser = this.hotelUserService.GetById(id);

            var room = this.roomService.GetById(rooms);

            this.reservationService.Create(room, hotelUser, adultsCount, childrensCount, startDate, endDate, breakfast,
                allInclusive, price, roomType);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return this.View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var reservation = this.reservationService.GetById(id);

            var adults = new List<Client>();
            var childrens = new List<Client>();

            foreach (var clientReservation in reservation.ClientsReservations)
            {
                var client = this.clientService.GetById(clientReservation.ClientId);

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
            var reservation = this.reservationService.GetById(id);

            var editReservation = new EditReservationViewModel(reservation.Id, reservation.StartDate,
                reservation.EndDate, reservation.AdultsCount, reservation.ChildrensCount, reservation.RoomType,
                reservation.Room, reservation.Breakfast, reservation.AllInclusive, reservation.Price, this.roomService.GetAll());

            return this.View(editReservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, DateTime startDate, DateTime endDate, int adultsCount,
            int childrensCount, RoomType roomType, string rooms, bool breakfast, bool allInclusive, double price)
        {
            var room = this.roomService.GetById(rooms);

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
            var reservation = this.reservationService.GetById(id);

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
                var adult = this.clientService.GetById(adultId);
                clients.Add(adult);
            }

            foreach (var childrenId in childrens)
            {
                var children = this.clientService.GetById(childrenId);
                clients.Add(children);
            }

            this.reservationService.AddClients(clients, id);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public JsonResult FiltrateRooms(DateTime startDate, DateTime endDate, int adultsCount, int childrensCount, RoomType roomType)
        {
            IEnumerable<Room> rooms = new List<Room>();

            if (startDate == default(DateTime) && endDate == default(DateTime) && adultsCount == 0 && childrensCount == 0)
            {
                rooms = this.roomService.GetAll().OrderBy(x => x.Number).Where(x => x.Type == roomType);
            }
            else
            {
                rooms = this.roomService.GetAllFreeRoomsByRequirments(startDate, endDate, childrensCount + adultsCount, roomType);
            }

            return Json(rooms);
        }

        public JsonResult CalculatePrice(int adultsCount, int childrensCount, string roomId, DateTime startDate, DateTime endDate)
        {
            double price = 0.0;

            if (roomId != null && startDate != default(DateTime) && endDate != default(DateTime))
            {
                var room = this.roomService.GetById(roomId);

                price = this.reservationService.CalculatePrice(adultsCount, childrensCount, room, startDate, endDate);
            }


            return Json(price);
        }

        [HttpGet]
        public JsonResult SearchReservations(string term)
        {
            var reservations = new List<ReservationViewModel>();

            foreach (var reservation in this.reservationService.GetAll())
            {
                var reservationViewModel = new ReservationViewModel(reservation.Id, reservation.User.UserName, reservation.StartDate, 
                    reservation.EndDate, reservation.AdultsCount, reservation.ChildrensCount, reservation.Room.Type, reservation.Room.Number,
                    reservation.Breakfast, reservation.AllInclusive, reservation.Price, reservation.ClientsReservations.Count);

                reservations.Add(reservationViewModel);
            }

            DateTime date;

            if (DateTime.TryParse(term, out date))
            {
                reservations = reservations
                    .Where(x => x.StartDate == date
                    || x.EndDate == date)
                    .ToList();
            }

            return Json(reservations);
        }
    }
}