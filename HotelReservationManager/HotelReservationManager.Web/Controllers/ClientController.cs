using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using HotelReservationManager.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly IHotelUserService hotelUserService;

        public ClientController(IClientService clientService, IHotelUserService hotelUserService)
        {
            this.clientService = clientService;
            this.hotelUserService = hotelUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new CreateClientViewModel();
            return this.View(createUserViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientViewModel createClientViewModel, string userId)
        {
            this.clientService.Create(
            createClientViewModel.FirstName,
            createClientViewModel.ThirdName,
            createClientViewModel.PhoneNumber, createClientViewModel.Email, createClientViewModel.Years);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = new ClientsListViewModel();
            TransferClientsToViewModel(list.Clients);
            return this.View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var client = this.clientService.GetById(id);

            var editClientViewModel = new ClientViewModel(client.Id, client.FirstName,
                client.ThirdName, client.Telephone, client.Email,
                client.IsAdult);

            return this.View(editClientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel clientViewModel)
        {
            this.clientService.Edit(clientViewModel.Id, clientViewModel.FirstName,
                clientViewModel.ThirdName, clientViewModel.PhoneNumber,
                 clientViewModel.Email, clientViewModel.IsAdult);

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(string id)
        {
            this.clientService.Delete(id);

            return this.RedirectToAction("List");
        }


        private void TransferClientsToViewModel(List<ClientViewModel> list)
        {
            foreach (var client in this.clientService.GetAll())
            {
                var clientsViewModel = new ClientViewModel(client.Id, client.FirstName,
                    client.ThirdName, client.Telephone, client.Email,
                    client.IsAdult);

                list.Add(clientsViewModel);
            }
        }
    }
}