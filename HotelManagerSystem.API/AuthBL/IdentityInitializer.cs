using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.AuthBL
{
    public class IdentityInitializer
    {
        public static async Task SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await CreateAdminRole(roleManager);
            await CreateAdminUser(userManager);
        }

        private static async Task CreateAdminRole(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await roleManager.CreateAsync(adminRole);
            }
        }

        private static async Task CreateAdminUser(UserManager<User> userManager)
        {
            var adminUser = await userManager.FindByNameAsync("admin");

            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin",
                    FullName = "Admin",
                    Email = "admin@gmail.com"
                };

                var result = await userManager.CreateAsync(adminUser, "Password123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}