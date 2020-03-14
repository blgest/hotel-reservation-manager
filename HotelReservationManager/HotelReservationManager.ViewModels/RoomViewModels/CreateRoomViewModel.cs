using HotelReservationManager.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.RoomViewModels
{
    public class CreateRoomViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive Capacity greater then 1 allowed")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Must be selected some Type")]
        public RoomType Type { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive Price On Bed For Adult allowed")]
        public double PriceOnBedForAdult { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive Price On Bed For Children allowed")]
        public double PriceOnBedForChildren { get; set; }

        [Required]
        [Range(101, int.MaxValue, ErrorMessage = "Only positive Number greater then 101 allowed")]
        public int Number { get; set; }
    }
}

