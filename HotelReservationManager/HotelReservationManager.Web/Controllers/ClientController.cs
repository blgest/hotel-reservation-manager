using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using HotelReservationManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
            var clientViewModel = new ClientViewModel();
            return this.View(clientViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel clientViewModel)
        {
            this.clientService.Create(clientViewModel);
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

                foundClients = this.clients
                    .Where(x => x.FirstName.ToLower().Contains(searchString)
                    || x.LastName.ToLower().Contains(searchString)).ToList();
            }

            int pageSize = 5;
            return View(PaginatedList<ClientViewModel>.Create(foundClients, pageNumber ?? 1, pageSize));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var client = clients.FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                return this.RedirectToAction("List");
            }
            return this.View(client);
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