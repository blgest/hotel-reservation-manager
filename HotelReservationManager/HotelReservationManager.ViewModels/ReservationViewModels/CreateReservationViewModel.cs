using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class CreateReservationViewModel
    {
        public CreateReservationViewModel()
        {
            this.Rooms = new List<Room>();
        }

        [Required(ErrorMessage = "Must be entered some Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Must be entered some End Date")]
        public DateTime EndDate { get; set; }

        [Required()]
        public int AdultsCount { get; set; }

        [Required()]
        public int ChildrensCount { get; set; }

        [Required(ErrorMessage = "Must be selected some Type")]
        public RoomType RoomType { get; set; }

        [Required(ErrorMessage = "Must be selected some Room")]
        public IEnumerable<Room> Rooms { get; set; }

        public bool Breakfast { get; set; }

        public bool AllInclusive { get; set; }
        
        [Required]
        [Range(10, 50000, ErrorMessage = "The reservation should be in range from 10 to 50,000")]
        public double Price { get; set; }

        public string RoomId { get; set; }
        public Room Room { get; set; }

        public string Id { get; set; }

        public HotelUser User { get; set; }
    }
}
