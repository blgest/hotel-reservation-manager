using HotelReservationManager.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationManager.ViewModels.RoomViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel(string id, int capacity, RoomType type, double priceOnBedForAdult, 
            double priceOnBedForChildren, int number)
        {
            Id = id;
            Capacity = capacity;
            Type = type;
            PriceOnBedForAdult = priceOnBedForAdult;
            PriceOnBedForChildren = priceOnBedForChildren;
            Number = number;
        }

        public RoomViewModel(string id, int capacity, RoomType type, double priceOnBedForAdult, double priceOnBedForChildren, 
            int number, bool isFree) : this(id, capacity, type, priceOnBedForAdult, priceOnBedForChildren, number)
        {
            IsFree = isFree;
        }

        public RoomViewModel()
        {

        }

        public string Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive Capacity graeter then 1 allowed")]
        public int Capacity { get; set; }

        [Required(ErrorMessage ="Must be selected some Type")]
        public RoomType Type { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive Price On Bed For Adult allowed")]
        public double PriceOnBedForAdult { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive Price On Bed For Children allowed")]
        public double PriceOnBedForChildren { get; set; }

        [Required]
        [Range(101, int.MaxValue, ErrorMessage = "Only positive Number gereater then 101 allowed")]
        public int Number { get; set; }

        public bool IsFree { get; set; }
    }
}
