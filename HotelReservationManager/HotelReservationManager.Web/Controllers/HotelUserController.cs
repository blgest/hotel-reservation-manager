using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelReservationManager.Web.Models;

namespace HotelReservationManager.Web.Controllers
{
    public class HotelUserController : Controller
    {
        private readonly IHotelUserService hotelUserService;
        private readonly List<UserViewModel> users;

        public HotelUserController(IHotelUserService hotelUserService)
        {
            this.hotelUserService = hotelUserService;
            this.users = this.hotelUserService.GetAll();
        }

        //Create -> Identity -> Register

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ActiveList(string currentFilter, string searchString, int? pageNumber)
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

            var foundUsers = SearchUsers(searchString)
                .Where(x => x.EndDate == default(DateTime))
                .ToList();

            int pageSize = 5;
            return View(PaginatedList<UserViewModel>.Create(foundUsers, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BlockedList(string currentFilter, string searchString, int? pageNumber)
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

            var foundUsers = SearchUsers(searchString).Where(x => x.EndDate != default(DateTime)).ToList();

            int pageSize = 5;
            return View(PaginatedList<UserViewModel>.Create(foundUsers, pageNumber ?? 1, pageSize));
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditActiveUser(string id)
        {
            var activeUser = this.hotelUserService.GetDataModelById(id);

            var editActiveUserViewModel = new UserViewModel(activeUser.Id, activeUser.UserName, activeUser.FirstName,
                activeUser.SecondName, activeUser.ThirdName, activeUser.UCN, activeUser.PhoneNumber, activeUser.Email,
                activeUser.StartDate, default(DateTime));

            return this.View(editActiveUserViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditActiveUser(UserViewModel activeUserViewModel)
        {
            this.hotelUserService.Edit(activeUserViewModel);
            return this.RedirectToAction("ActiveList", "HotelUser");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditBlockedUser(string id)
        {
            var blockedUser = this.hotelUserService.GetDataModelById(id);

            var editActiveUserViewModel = new UserViewModel(blockedUser.Id, blockedUser.UserName, blockedUser.FirstName,
                blockedUser.SecondName, blockedUser.ThirdName, blockedUser.UCN, blockedUser.PhoneNumber, blockedUser.Email,
                blockedUser.StartDate, blockedUser.EndDate);

            return this.View(editActiveUserViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditBlockedUser(UserViewModel blockedUserViewModel)
        {
            this.hotelUserService.Edit(blockedUserViewModel);
            return this.RedirectToAction("BlockedList", "HotelUser");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Block(string id)
        {
            this.hotelUserService.Block(id);
            return this.RedirectToAction("BlockedList", "HotelUser");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Activate(string id)
        {
            this.hotelUserService.Activate(id);
            return this.RedirectToAction("ActiveList", "HotelUser");
        }

        private IEnumerable<UserViewModel> SearchUsers(string term)
        {
            IEnumerable<UserViewModel> foundUsers = this.users;

            if (!String.IsNullOrEmpty(term))
            {
                term = term.ToLower();

                foundUsers = this.users
                    .OrderBy(x => x.Role)
                    .Where(x => x.Username.ToLower().Contains(term)
                    || x.FirstName.ToLower().Contains(term)
                    || x.SecondName.ToLower().Contains(term)
                    || x.ThirdName.ToLower().Contains(term));
            }

            return foundUsers;
        }
    }
}