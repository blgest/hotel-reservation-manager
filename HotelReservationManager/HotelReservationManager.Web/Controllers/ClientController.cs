using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.ClientViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
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
            this.clientService.Create(
                createClientViewModel.FirstName,
                createClientViewModel.ThirdName,
                createClientViewModel.PhoneNumber,
                createClientViewModel.Email,
                createClientViewModel.Years);

            return this.RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return this.View();
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

        [HttpGet]
        public JsonResult SearchClients(string term)
        {
            var clients = new List<ClientViewModel>();

            foreach (var client in this.clientService.GetAll())
            {
                var clientViewModel = new ClientViewModel(client.Id, client.FirstName, client.ThirdName, client.Telephone, client.Email,
                    client.IsAdult);

                clients.Add(clientViewModel);
            }

            if (term != null)
            {
                term = term.ToLower();

                clients = clients
                    .Where(x => x.FirstName.ToLower().Contains(term)
                    || x.ThirdName.ToLower().Contains(term))
                    .ToList();
            }

            return Json(clients);
        }
    }
}