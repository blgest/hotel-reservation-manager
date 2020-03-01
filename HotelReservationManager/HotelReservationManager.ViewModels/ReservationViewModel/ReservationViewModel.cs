using HotelReservationManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationManager.ViewModels.ReservationViewModel
{
    public class ReservationViewModel
    {
      

        public ReservationViewModel()
        {

        }

        public ReservationViewModel(string id, Room room, IEnumerable<Client> clients, HotelUser user, 
            DateTime startDate, DateTime endDate, bool breakfast, bool allInclusive, double price)
        {
            Id = id;
            Room = room;
            Clients = clients;
            User = user;
            StartDate = startDate;
            EndDate = endDate;
            Breakfast = breakfast;
            AllInclusive = allInclusive;
            Price = price;
        }

        public string Id { get; set; }

        [Required]
        public Room Room { get; set; }

        [Required]
        public IEnumerable<Client> Clients { get; set; }

        [Required]
        public HotelUser User { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [EmailAddress]
        public DateTime EndDate { get; set; }

        [Required]
        public bool Breakfast { get; set; }

        [Required]
        public bool AllInclusive { get; set; }

        public double Price { get; set; }
    }
}

