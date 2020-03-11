using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Web;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class CreateReservationViewModel : PageModel
    {
        public CreateReservationViewModel()
        {
            this.Rooms = new List<Room>();
        }

        public HotelUser HotelUser { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrensCount { get; set; }

        public RoomType RoomType { get; set; }

        [BindProperty]
        public List<Room> Rooms { get; set; }

        public bool Breakfast { get; set; }

        public bool AllInclusive { get; set; }

        public double Price { get; set; }

        public void OnPost()
        {
            var rooms = Request.Form["Rooms"];
        }
    }
}
