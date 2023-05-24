using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.Service
{
    public interface ITokenService
    {
        string CreateToken(User user, List<IdentityRole> role);
    }
}
