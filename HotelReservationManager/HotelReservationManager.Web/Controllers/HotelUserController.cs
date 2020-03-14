using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HotelReservationManager.Data.Models;

namespace HotelReservationManager.Web.Controllers
{
    public class HotelUserController : Controller
    {
        private readonly IHotelUserService hotelUserService;

        private readonly UserManager<HotelUser> userManager;

        public HotelUserController(IHotelUserService hotelUserService, UserManager<HotelUser> userManager)
        {
            this.hotelUserService = hotelUserService;
            this.userManager = userManager;
        }

        //Create -> Identity -> Register

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ActiveList()
        {
            return this.View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BlockedList()
        {
            return this.View();
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditActiveUser(string id)
        {
            var activeUser = this.hotelUserService.GetById(id);

            var editActiveUserViewModel = new ActiveUserViewModel(activeUser.Id, activeUser.UserName, activeUser.FirstName,
                activeUser.SecondName, activeUser.ThirdName, activeUser.UCN, activeUser.PhoneNumber, activeUser.Email,
                activeUser.StartDate);

            return this.View(editActiveUserViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditActiveUser(ActiveUserViewModel activeUserViewModel)
        {
            this.hotelUserService.Edit(activeUserViewModel.Id, activeUserViewModel.Username, activeUserViewModel.FirstName,
                 activeUserViewModel.SecondName, activeUserViewModel.ThirdName, activeUserViewModel.UCN, activeUserViewModel.PhoneNumber,
                 activeUserViewModel.Email, activeUserViewModel.StartDate, default(DateTime));

            return this.RedirectToAction("ActiveList", "HotelUser");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditBlockedUser(string id)
        {
            var blockedUser = this.hotelUserService.GetById(id);

            var editActiveUserViewModel = new BlockedUserViewModel(blockedUser.Id, blockedUser.UserName, blockedUser.FirstName,
                blockedUser.SecondName, blockedUser.ThirdName, blockedUser.UCN, blockedUser.PhoneNumber, blockedUser.Email,
                blockedUser.StartDate, blockedUser.EndDate);

            return this.View(editActiveUserViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditBlockedUser(BlockedUserViewModel blockedUserViewModel)
        {
            this.hotelUserService.Edit(blockedUserViewModel.Id, blockedUserViewModel.Username, blockedUserViewModel.FirstName,
                blockedUserViewModel.SecondName, blockedUserViewModel.ThirdName, blockedUserViewModel.UCN, blockedUserViewModel.PhoneNumber,
                blockedUserViewModel.Email, blockedUserViewModel.StartDate, blockedUserViewModel.EndDate);

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

        [HttpGet]
        public JsonResult SearchActiveUsers(string term)
        {
            var activeUsers = new List<ActiveUserViewModel>();

            foreach (var activeUser in this.hotelUserService.GetAllActive())
            {
                var role = userManager.GetRolesAsync(activeUser).Result;

                var activeUserViewModel = new ActiveUserViewModel(activeUser.Id, activeUser.UserName, activeUser.FirstName,
                    activeUser.SecondName, activeUser.ThirdName, activeUser.UCN, activeUser.PhoneNumber, activeUser.Email,
                    activeUser.StartDate, role[0]);

                activeUsers.Add(activeUserViewModel);
            }

            activeUsers.OrderBy(x => x.Role == "Admin");

            if (term != null)
            {
                term = term.ToLower();

                activeUsers = activeUsers
                    .Where(x => x.Username.ToLower().Contains(term)
                    || x.FirstName.ToLower().Contains(term)
                    || x.SecondName.ToLower().Contains(term)
                    || x.ThirdName.ToLower().Contains(term))
                    .ToList();
            }

            return Json(activeUsers);
        }

        [HttpGet]
        public JsonResult SearchBlockedUsers(string term)
        {
            var blockedUsers = new List<BlockedUserViewModel>();

            foreach (var blockedUser in this.hotelUserService.GetAllBlocked())
            {
                var role = userManager.GetRolesAsync(blockedUser).Result;

                var blockedserViewModel = new BlockedUserViewModel(blockedUser.Id, blockedUser.UserName, blockedUser.FirstName,
                    blockedUser.SecondName, blockedUser.ThirdName, blockedUser.UCN, blockedUser.PhoneNumber, blockedUser.Email,
                    blockedUser.StartDate, blockedUser.EndDate, role[0]);

                blockedUsers.Add(blockedserViewModel);
            }

            if (term != null)
            {
                term = term.ToLower();

                blockedUsers = blockedUsers
                    .Where(x => x.Username.ToLower().Contains(term)
                    || x.FirstName.ToLower().Contains(term)
                    || x.SecondName.ToLower().Contains(term)
                    || x.ThirdName.ToLower().Contains(term))
                    .ToList();
            }

            return Json(blockedUsers);
        }
    }
}