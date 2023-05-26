using System.Security.Claims;
using HotelManagerSystem.API.AuthBL.CurrentModels;
using HotelManagerSystem.API.AuthBL.Data;
using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AuthManager _authManager;

        public AuthController(IMediator mediator, AuthManager authManager)
        {
            _mediator = mediator;
            _authManager = authManager;
        }

        [HttpPost("register")]
        public async Task<Response> Register(RegisterUserRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("login")]
        public async Task<AuthResponse> Login(LoginUserRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        [HttpPost("refresh-token")]
        public async Task<AuthResponse> RefreshToken(TokenModel tokenModel)
        {
            var response = await _authManager.RefreshToken(tokenModel);
            return response;
        }
        

        [HttpGet("getCurrentUser")]
        public async Task<CurrentUserResponse> GetCurrentUser()
        {
            ClaimsPrincipal currentUserClaims = User;
            return await _authManager.GetCurrentUser(currentUserClaims);
        }

    }
}
