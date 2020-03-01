using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.ViewModels.RoomViewModels
{
    public class CreateRoomViewModel
    {
        [Required]
        public int Capacity { get; set; }

        [Required]
        public RoomType Type { get; set; }

        [Required]
        public double PriceOnBedForAdult { get; set; }

        [Required]
        public double PriceOnBedForChildren { get; set; }

        [Required]
        public int Number { get; set; }
    }
}

