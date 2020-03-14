using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.ReservationViewModels
{
    public class EditReservationViewModel
    {
        public EditReservationViewModel(string id, DateTime startDate, DateTime endDate, int adultsCount, 
            int childrensCount, RoomType roomType, Room room, bool breakfast, bool allInclusive, double price, IEnumerable<Room> rooms)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            AdultsCount = adultsCount;
            ChildrensCount = childrensCount;
            RoomType = roomType;
            Room = room;
            Breakfast = breakfast;
            AllInclusive = allInclusive;
            Price = price;
            Rooms = rooms;
        }

        public EditReservationViewModel()
        {

        }

        public string Id { get; set; }

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

        public Room Room { get; set; }

        [Range(typeof(bool), "false", "true", ErrorMessage = "Breakfast must be true or false")]
        public bool Breakfast { get; set; }

        [Range(typeof(bool), "false", "true", ErrorMessage = "All Inclusive must be true or false")]
        public bool AllInclusive { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
