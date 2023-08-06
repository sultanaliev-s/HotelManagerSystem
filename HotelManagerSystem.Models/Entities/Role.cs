using Microsoft.AspNetCore.Identity;


namespace HotelManagerSystem.Models.Entities;

public class Role : IdentityRole
{
    public const string Owner = "Owner";
}