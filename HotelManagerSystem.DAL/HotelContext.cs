using Microsoft.EntityFrameworkCore;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelManagerSystem.DAL
{
    public class HotelContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<ClientReview> ClientsReviews { get; set; } 
        public DbSet<Hotel> Hotels { get; set; } 
        public DbSet<HotelCategory> HotelsCategories { get; set; } 
        public DbSet<HotelFoto> HotelsFotos { get; set; } 
        public DbSet<HotelType> HotelsTypes { get; set; } 
        public DbSet<HotelServices> HotelsServises { get; set; } 
        public DbSet<HotelsServices> HotelsServices2 { get; set; } 
        public DbSet<Room> Rooms { get; set; } 
        public DbSet<RoomReservation> RoomsReservations { get; set; } 
        public DbSet<RoomType> RoomsTypes { get; set; } 
        public DbSet<Сouchette> Couchettes { get; set; } 
        public DbSet<Country> Countries { get; set; } 
        public DbSet<City> Cities { get; set; } 
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("PgDbContextConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'PgDbContextConnection' not found.");

            optionsBuilder.UseNpgsql(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }


    }
}