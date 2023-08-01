using System.Security.Claims;
using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.DAL.AuthBL.Data;
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
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var response = await _mediator.Send(request);
            return response.StatusCode switch
            {
                200 => Created("", null),
                400 => BadRequest(new ErrorResponse(response.Message)),
                _ => StatusCode(response.StatusCode, new ErrorResponse(response.Message))
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var response = await _mediator.Send(request);
            return response.StatusCode switch
            {
                200 => Ok(response.TokenResponse),
                400 => BadRequest(new ErrorResponse(response.Message)),
                404 => NotFound(new ErrorResponse(response.Message)),
                _ => StatusCode(response.StatusCode, new ErrorResponse(response.Message))
            };
        }
        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            var response = await _authManager.RefreshToken(tokenModel);
            return response.StatusCode switch
            {
                200 => Ok(response.TokenResponse),
                400 => BadRequest(new ErrorResponse(response.Message)),
                _ => StatusCode(response.StatusCode, response.Message)

            };
        }

        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            ClaimsPrincipal currentUserClaims = User;
            var response = await _authManager.GetCurrentUser(currentUserClaims);
            return response.StatusCode switch
            {
                200 => Ok(response.CurrentUser),
                404 => NotFound(new ErrorResponse(response.Message)),
                _ => StatusCode(response.StatusCode, response.Message)
            };
        }

    }
}
