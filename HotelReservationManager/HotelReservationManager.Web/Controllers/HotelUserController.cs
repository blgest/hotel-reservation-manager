using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using HotelReservationManager.ViewModels;
using HotelReservationManager.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class HotelUserController : Controller
    {
        private readonly IHotelUserService hotelUserService;

        public HotelUserController(IHotelUserService hotelUserService)
        {
            this.hotelUserService = hotelUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ActiveList()
        {
            var activeList = new ActiveUsersListViewModel();
            TransferActiveUsersToViewModel(activeList.Users);
            return this.View(activeList);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BlockedList()
        {
            var blockedList = new BlockedUsersListViewModel();
            TransferBlockedUsersToViewModel(blockedList.Users);
            return this.View(blockedList);
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


        private void TransferBlockedUsersToViewModel(List<BlockedUserViewModel> list)
        {
            foreach (var user in hotelUserService.GetAllBlocked())
            {
                var blockedUserViewModel = new BlockedUserViewModel(user.Id, user.UserName, user.FirstName,
                    user.SecondName, user.ThirdName, user.UCN, user.PhoneNumber, user.Email,
                    user.StartDate, user.EndDate);

                list.Add(blockedUserViewModel);
            }
        }

        private void TransferActiveUsersToViewModel(List<ActiveUserViewModel> list)
        {
            foreach (var user in hotelUserService.GetAllActive())
            {
                var activeUserViewModel = new ActiveUserViewModel(user.Id, user.UserName, user.FirstName,
                    user.SecondName, user.ThirdName, user.UCN, user.PhoneNumber, user.Email,
                    user.StartDate);

                list.Add(activeUserViewModel);
            }
        }
    }
}