using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.AuthBL.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
