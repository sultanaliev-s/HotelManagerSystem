using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Entities.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetConnectionString("DbConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("Connection string 'DbConnection' not found.");
            }

            optionsBuilder.UseNpgsql(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Cities)
                .WithMany(y => y.Addresses)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Countries)
                .WithMany(c => c.Address)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Hotel)
                .WithMany(y => y.Addresses)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<City>()
                .HasMany(y => y.Addresses)
                .WithOne(a => a.Cities)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ClientReview>()
                .HasOne(a => a.Hotel)
                .WithMany(y => y.ClientReviews)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ClientReview>()
                .HasOne(a => a.User)
                .WithMany(y => y.clientReviews)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Address)
                .WithOne(a => a.Countries)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Hotel>()
                .HasMany(y => y.Addresses)
                .WithOne(a => a.Hotel)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Hotel>()
                .HasMany(y => y.ClientReviews)
                .WithOne(a => a.Hotel)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Hotel>()
                .HasMany(y => y.Fotos)
                .WithOne(a => a.Hotel)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Hotel>()
                .HasMany(y => y.Rooms)
                .WithOne(a => a.Hotel)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Hotel>()
                .HasOne(a => a.Category)
                .WithMany(y => y.Hotels)
                .HasForeignKey(a => a.HotelCategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Hotel>()
                .HasOne(a => a.Type)
                .WithMany(y => y.Hotels)
                .HasForeignKey(a => a.HotelTypeId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Hotel>()
                .HasOne(a => a.User)
                .WithMany(y => y.Hotels)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.city)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.cityId)
                .IsRequired();

            modelBuilder.Entity<HotelCategory>()
                .HasMany(y => y.Hotels)
                .WithOne(a => a.Category)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HotelFoto>()
                .HasOne(a => a.Hotel)
                .WithMany(y => y.Fotos)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<HotelsServices>()
                .HasKey(hs => new { hs.HotelId, hs.ServiceId });

            modelBuilder.Entity<HotelType>()
                .HasMany(y => y.Hotels)
                .WithOne(a => a.Type)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Room>()
                .HasOne(a => a.Hotel)
                .WithMany(y => y.Rooms)
                .HasForeignKey(a => a.HotelId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Room>()
                .HasOne(c => c.RoomType)
                .WithMany(c => c.Rooms)
                .HasForeignKey(c => c.RoomTypeId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Room>()
                .HasOne(c => c.Сouchette)
                .WithOne(c => c.Room)
                .HasForeignKey<Сouchette>(c => c.RoomId)
                .IsRequired();

            modelBuilder.Entity<RoomReservation>()
                .HasOne(a => a.User)
                .WithMany(y => y.roomReservations)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<RoomReservation>()
                .HasOne(x => x.Room)
                .WithMany(y => y.Reservations)
                .HasForeignKey(a => a.RoomId)
                .IsRequired();

            modelBuilder.Entity<RoomType>()
                .HasMany(c => c.Rooms)
                .WithOne(a => a.RoomType)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasMany(y => y.clientReviews)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>()
                .HasMany(y => y.Hotels)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>()
                .HasMany(y => y.roomReservations)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}