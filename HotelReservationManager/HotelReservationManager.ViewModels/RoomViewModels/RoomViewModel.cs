using HotelReservationManager.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.RoomViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel(string id, int capacity, RoomType type, bool isFree,
            double priceOnBedForAdult, double priceOnBedForChildren, int number)
        {
            Id = id;
            Capacity = capacity;
            Type = type;
            IsFree = isFree;
            PriceOnBedForAdult = priceOnBedForAdult;
            PriceOnBedForChildren = priceOnBedForChildren;
            Number = number;
        }

        public RoomViewModel()
        {

        }

        public string Id { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public RoomType Type { get; set; }

        [Required]
        public bool IsFree { get; set; }

        [Required]
        public double PriceOnBedForAdult { get; set; }

        [Required]
        public double PriceOnBedForChildren { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
