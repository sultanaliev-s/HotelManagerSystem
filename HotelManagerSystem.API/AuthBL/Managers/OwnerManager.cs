using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HotelManagerSystem.API.Extensions;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.Common;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Entities.ModelOwner;
using Microsoft.AspNetCore.Identity;

namespace HotelManagerSystem.API.AuthBL.Managers
{
    public class OwnerManager
    {
        private readonly UserManager<User> _userManager;
        private readonly HotelContext _dbContext;
        private readonly IConfiguration _configuration;

        public OwnerManager(UserManager<User> userManager, HotelContext dbContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Response> RegisterOwner(RegisterOwnerRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Role.Owner);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, Role.Owner)
                };

                var token = claims.CreateJwtToken(_configuration);
                var refreshToken = _configuration.GenerateRefreshToken();

                var registrationResponse = new RegistrationResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken
                };

                return new Response(200, true, "Owner registered successfully");
            }
            else
            {
                string aggregatedErrorMessages = string.Join("\n", result.Errors.Select(e => e.Description));
                throw new DException(aggregatedErrorMessages);
            }
        }

        public async Task<OwnerViewModel> GetOwnerById(string ownerId)
        {
            var owner = await _userManager.FindByIdAsync(ownerId);

            if (owner == null)
            {
                return null;
            }

            var ownerViewModel = new OwnerViewModel
            {
                Id = int.Parse(owner.Id),
                FullName = owner.FullName,
                Email = owner.Email,
            };

            return ownerViewModel;
        }

        public async Task<OwnerViewModel> GetCurrentOwner(ClaimsPrincipal userClaims)
        {
            var user = await _userManager.GetUserAsync(userClaims);

            if (user == null)
            {
                return null;
            }

            var ownerViewModel = new OwnerViewModel
            {
                Id = int.Parse(user.Id),
                FullName = user.FullName,
                Email = user.Email
            };

            return ownerViewModel;
        }

        public async Task<Response> UpdateOwner(UpdateOwnerRequest request)
        {
            var ownerId = request.Id.ToString();
            var owner = await _userManager.FindByIdAsync(ownerId);

            if (owner == null)
            {
                throw new DException("Owner not found");
            }

            owner.FullName = request.FullName;
            owner.Email = request.Email;

            var result = await _userManager.UpdateAsync(owner);

            if (!result.Succeeded)
            {
                string aggregatedErrorMessages = string.Join("\n", result.Errors
                    .Select(e => e.Description));

                throw new DException(aggregatedErrorMessages);
            }

            return new Response(200, true, "Owner updated successfully");
        }

        public async Task<bool> DeleteOwner(string ownerId)
        {
            var owner = await _userManager.FindByIdAsync(ownerId);

            if (owner == null)
            {
                return false;
            }

            await _userManager.DeleteAsync(owner);

            return true;
        }
    }
}
