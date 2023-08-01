using System.Security.Cryptography;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.AuthBL.Data
{
    public static class DataSeeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            var rolesToSeed = new[] { "Admin", "User" };

            var existingRoles = rolesToSeed.Length;

            foreach (var roleName in rolesToSeed)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    existingRoles--;
                    var role = new IdentityRole { Name = roleName };
                    await roleManager.CreateAsync(role);
                }
            }

            if (existingRoles == 0)
            {
                var email = Environment.GetEnvironmentVariable("ADMIN_EMAIL");
                var admin = new User()
                {
                    FullName = "Admin",
                    Email = email,
                    UserName = email,
                    CheckingAccount = "",
                    IsEmailConfirmed = true,
                };

                await userManager.CreateAsync(admin,
                    "Hello1!" + Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)));
                await userManager.AddToRolesAsync(admin, new[] { "Admin", "User" });
            }
        }
    }
}
