using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelReservationManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelReservationManagerDbContext dbContext;

        public HomeController(HotelReservationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            if (this.dbContext.Users.Count() == 0)
            {
                return Redirect("/Identity/Account/Register");
            }
            return this.View("Home");
        }
    }
}
