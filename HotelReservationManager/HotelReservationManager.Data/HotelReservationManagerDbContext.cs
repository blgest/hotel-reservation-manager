using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace HotelReservationManager.Data
{
    public class HotelReservationManagerDbContext : IdentityDbContext<HotelUser, IdentityRole, string>
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ClientReservations> ClientReservations { get; set; }

        public HotelReservationManagerDbContext(DbContextOptions<HotelReservationManagerDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ClientReservations>().HasKey(cr => new { cr.ClientId, cr.ReservationId });
        }
    }
}
