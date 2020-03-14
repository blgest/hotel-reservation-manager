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

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive Adults Count allowed")]
        public int AdultsCount { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive Childrens Count allowed")]
        public int ChildrensCount { get; set; }

        [Required(ErrorMessage = "Must be selected some Type")]
        public RoomType RoomType { get; set; }

        [Required(ErrorMessage = "Must be selected some Room")]
        public IEnumerable<Room> Rooms { get; set; }

        public bool Breakfast { get; set; }

        public bool AllInclusive { get; set; }
        
        [Required]
        public double Price { get; set; }
    }
}
