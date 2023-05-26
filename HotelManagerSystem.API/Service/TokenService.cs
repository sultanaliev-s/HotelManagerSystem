using System.IdentityModel.Tokens.Jwt;
using HotelManagerSystem.API.Extensions;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(User user, List<IdentityRole> roles)
        {
            var token = user
            .CreateClaims(roles)
            .CreateJwtToken(_configuration);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
