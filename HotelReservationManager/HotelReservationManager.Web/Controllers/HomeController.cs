using System.Threading.Tasks;
using HotelReservationManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelUserService hotelUserService;

        private readonly IReservationService reservationService;

        public HomeController(IHotelUserService hotelUserService, IReservationService reservationService)
        {
            this.hotelUserService = hotelUserService;
            this.reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            if (!hotelUserService.AreThereAnyUsers())
            {
                return Redirect("/Identity/Account/Register");
            }

            reservationService.CheckForExpiredReservations();

            return this.View("Home");
        }
    }
}
