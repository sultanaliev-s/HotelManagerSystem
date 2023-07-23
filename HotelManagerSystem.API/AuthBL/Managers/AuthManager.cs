using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HotelManagerSystem.API.AuthBL.CurrentModels;
using HotelManagerSystem.API.Configs;
using HotelManagerSystem.API.Extensions;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.API.Service;
using HotelManagerSystem.Common;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.AuthBL.CurrentModels;
using HotelManagerSystem.DAL.AuthBL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.ReservationRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HotelManagerSystem.API.AuthBL.Managers
{
    public class AuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMemoryCache _memoryCache;
        private readonly EmailService _emailService;
        private readonly SMTPConfig _config;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EmailManager _emailManager;
        private readonly HotelContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthManager(
            UserManager<User> userManager,
            SignInManager<User> signInManager, IMemoryCache memoryCache
            , EmailService emailService, Config config, ITokenService tokenService, IConfiguration configuration
            , RoleManager<IdentityRole> roleManager,
            EmailManager emailManager, HotelContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _memoryCache = memoryCache;
            _emailService = emailService;
            _config = config.SMTPConfig;
            _tokenService = tokenService;
            _configuration = configuration;
            _roleManager = roleManager;
            _emailManager = emailManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<AuthResponse> LoginUser(LoginUserRequest request, CancellationToken token)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new DException("User not found");
            }

            if (!user.IsEmailConfirmed)
            {
                throw new DException("User's email isn't confirmed");
            }

            var result = await _signInManager.PasswordSignInAsync(request.Email,
                request.Password, false, false);
            if (result.Succeeded)
            {
                var identityRoles = new List<IdentityRole>();
                var roles = await _userManager.GetRolesAsync(user);

                foreach (var roleName in roles)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    identityRoles.Add(role);
                }

                var accessToken = _tokenService.CreateToken(user, identityRoles);
                user.RefreshToken = _configuration.GenerateRefreshToken();
                user.RefreshTokenExpiryTime =
                    DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());
                await _userManager.UpdateAsync(user);
                return new AuthResponse(200, true, "Операция успешна!"
                    , user.FullName, accessToken, user.RefreshToken);
            }
            else if (result.IsLockedOut)
            {
                throw new DException("User account locked out");
            }
            else
            {
                throw new DException("Login Error");
            }
        }


        public async Task<Response> RegisterUser(RegisterUserRequest request,
            CancellationToken cancellationToken)
        {
            if (!await _emailManager.SendEmailAsync(request.Email))
            {
                return new Response(400, false, "We've already sent the code to your email. Please chek it");
            }

            var result = await RegisterUser(request);

            if (!result.Succeeded)
            {
                string aggregatedErrorMessages = string.Join("\n", result.Errors
                    .Select(e => e.Description));

                throw new DException(aggregatedErrorMessages);
            }

            return new Response(200, true, "Initial user created");
        }

        public async Task<CurrentUserResponse> GetCurrentUser(ClaimsPrincipal currentUserClaims)
        {
            var user = await _userManager.GetUserAsync(currentUserClaims);

            return GetCurrentUserResponse(user);
        }

        public CurrentUserResponse GetCurrentUserResponse(User user)
        {
            if (user == null)
            {
                return new CurrentUserResponse(404, false, "Current user not found", null);
            }

            var userVm = MapUser(user);

            return new CurrentUserResponse(200, true, "User recieved", userVm);
        }

        private UserViewModel MapUser(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                EmailConfirmed = user.IsEmailConfirmed,
                PhoneNumber = user.PhoneNumber,
            };
        }

        private void SetUserProperties(User user, string fullName, string email)
        {
            user.FullName = fullName;
            user.Email = email;
            user.UserName = email;
            user.CheckingAccount = "";
        }

        private async Task<IdentityResult> RegisterUser(RegisterUserRequest request)
        {
            var user = new User();
            SetUserProperties(user, request.FullName, request.Email);

            var result = await _userManager.CreateAsync(user, request.Password);

            return result;
        }

        public async Task<AuthResponse> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                return new AuthResponse(400, false, "Client server error!", null, null, null);
            }

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {
                return new AuthResponse(400, false, "Неверный \"Access\" или \"Refresh\" токен!", null, null, null);
            }

            var username = principal.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new AuthResponse(400, false, "Неверный \"Access\" или \"Refresh\" токен!", null, null, null);
            }

            var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _configuration.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new AuthResponse(200, true, "Success!", user.FullName,
                new JwtSecurityTokenHandler().WriteToken(newAccessToken), newRefreshToken);
        }

        public async Task<Response> MakeReservation(RoomReservationRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new DException("User not found");
            }

            var room = await _dbContext.Rooms.FindAsync(request.RoomId);
            if (room == null)
            {
                throw new DException("Room not found");
            }

            bool isRoomAvailable = await IsRoomAvailable(room, request.StartDate, request.EndDate);
            if (!isRoomAvailable)
            {
                throw new DException("Room is not available for the specified dates");
            }

            var reservation = new RoomReservation
            {
                UserId = user.Id,
                User = user,
                Price = CalculateReservationPrice(room, request.StartDate, request.EndDate),
                ReserveStart = request.StartDate,
                ReserveEnd = request.EndDate,
                Person = request.Person,
                RoomId = room.Id,
                Room = room
            };

            _dbContext.RoomsReservations.Add(reservation);
            await _dbContext.SaveChangesAsync();

            return new Response(200, true, "Reservation made successfully");
        }

        public async Task<Response> CancelReservation(int reservationId)
        {
            var reservation = await _dbContext.RoomsReservations.FindAsync(reservationId);
            if (reservation == null)
            {
                throw new DException("Reservation not found");
            }

            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            var userId = _userManager.GetUserId(claimsPrincipal);

            if (userId != reservation.UserId)
            {
                throw new DException("Unauthorized to cancel this reservation");
            }

            _dbContext.RoomsReservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();

            return new Response(200, true, "Reservation canceled successfully");
        }

        private async Task<bool> IsRoomAvailable(Room room, DateTime startDate, DateTime endDate)
        {
            var existingReservations = await _dbContext.RoomsReservations
                .Where(r => r.RoomId == room.Id && r.ReserveEnd >= startDate && r.ReserveStart <= endDate)
                .ToListAsync();

            return !existingReservations.Any();
        }

        private decimal CalculateReservationPrice(Room room, DateTime startDate, DateTime endDate)
        {
            //стоимость = (количество дней) * (цена)
            int numDays = (int)(endDate - startDate).TotalDays;
            decimal totalPrice = numDays * room.Price;
            return totalPrice;
        }
    }
}
