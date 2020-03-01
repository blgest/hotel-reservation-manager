using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ReservationViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new ReservationViewModel();
            return this.View(createUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel reservationViewModel)
        {
            this.reservationService.Create(reservationViewModel.Room, reservationViewModel.User, reservationViewModel.Clients,
                reservationViewModel.StartDate, reservationViewModel.EndDate, reservationViewModel.Breakfast, reservationViewModel.AllInclusive
                );

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = new ReservationsListViewModel();
            TransferReservationToViewModel(list.Reservations);
            return this.View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var reservation = this.reservationService.GetById(id);

            var editReservation = new ReservationViewModel(reservation.Id,reservation.Room, reservation.Clients, reservation.User,
                reservation.StartDate, reservation.EndDate, reservation.Breakfast, reservation.AllInclusive,
                reservation.Price
                );

            return this.View(editReservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReservationViewModel reservationViewModel)
        {
            this.reservationService.Edit(reservationViewModel.Id, reservationViewModel.Room, reservationViewModel.User, reservationViewModel.Clients,
                reservationViewModel.StartDate, reservationViewModel.EndDate, 
                reservationViewModel.Breakfast, reservationViewModel.AllInclusive
                );

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(string id)
        {
            this.reservationService.Delete(id);

            return this.RedirectToAction("List");
        }


        private void TransferReservationToViewModel(List<ReservationViewModel> list)
        {
            foreach (var reservation in this.reservationService.GetAll())
            {
                var reservationViewModel = new ReservationViewModel(reservation.Id, reservation.Room, reservation.Clients, reservation.User,
                reservation.StartDate, reservation.EndDate, reservation.Breakfast, reservation.AllInclusive,
                reservation.Price
                );

                list.Add(reservationViewModel);
            }
        }

    }
}