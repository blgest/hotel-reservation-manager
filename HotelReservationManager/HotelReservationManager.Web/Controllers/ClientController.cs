using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data.Models;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
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
        public async Task<IActionResult> List()
        {
            return this.View(this.clients);
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

        [HttpGet]
        public JsonResult SearchClients(string term)
        {
            var foundClients = new List<ClientViewModel>();


            if (term != null)
            {
                term = term.ToLower();

                foundClients = this.clients
                    .Where(x => x.FirstName.ToLower().Contains(term)
                    || x.ThirdName.ToLower().Contains(term))
                    .ToList();
            }
            else
            {
                foundClients = this.clients;
            }

            return Json(foundClients);
        }
    }
}