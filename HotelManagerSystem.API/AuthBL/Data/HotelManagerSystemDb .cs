using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.API.AuthBL.Data;

public class HotelManagerSystemDb : IdentityDbContext<User>
{
    private readonly IServiceProvider _serviceProvider;
    public HotelManagerSystemDb(DbContextOptions<HotelManagerSystemDb> options, IServiceProvider serviceProvider)
        : base(options)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("HotelManagerSystemDbConnection")
                               ?? throw new InvalidOperationException(
                                   "Connection string 'HotelManagerSystemDbConnection' not found.");

        optionsBuilder.UseNpgsql(connectionString, builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        });
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
            
        User user = new User()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "Admin",
            FullName = "Admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            EmailConfirmed = true,
            IsEmailConfirmed = true,
            LockoutEnabled = false,
            AccessFailedCount = 0,
        };
            
        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, "Password123!");

        builder.Entity<User>().HasData(user);
        
        CreateAdminRole().GetAwaiter().GetResult();
    }
    
    private async Task CreateAdminRole()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await roleManager.CreateAsync(adminRole);
            }
        }
    }
}

