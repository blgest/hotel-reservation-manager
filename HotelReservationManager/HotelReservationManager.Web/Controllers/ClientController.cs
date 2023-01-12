using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using HotelReservationManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationManager.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly List<ClientViewModel> clients;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
            this.clients = this.clientService.GetAll();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createUserViewModel = new CreateClientViewModel();
            return this.View(createUserViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientViewModel createClientViewModel)
        {
            this.clientService.Create(createClientViewModel);

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

            var foundClients = this.clients;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();

                foundClients = this.clients.AsQueryable()
                    .Where(x => x.FirstName.ToLower().Contains(searchString)
                    || x.ThirdName.ToLower().Contains(searchString)).ToList();
            }

            int pageSize = 5;
            return View(PaginatedList<ClientViewModel>.Create(foundClients, pageNumber ?? 1, pageSize));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var client = clients.FirstOrDefault(x => x.Id == id);

            if (client != null)
            {
                return this.View(client);
            }

            return this.RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel clientViewModel)
        {
            this.clientService.Edit(clientViewModel);

            return this.RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(string id)
        {
            this.clientService.Delete(id);

            return this.RedirectToAction("List");
        }
    }
}