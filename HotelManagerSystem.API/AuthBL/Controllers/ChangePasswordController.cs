using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Configs;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Request.ChangePassword;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.API.Service;
using HotelManagerSystem.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HotelManagerSystem.API.AuthBL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChangePasswordController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AuthManager _authManager;
        private readonly EmailService _emailService;
        private readonly SMTPConfig _config;
        private readonly IMemoryCache _memoryCache;
        public ChangePasswordController(IMediator mediator, AuthManager authManager, EmailService emailService,
            Config config, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _authManager = authManager;
            _emailService = emailService;
            _config = config.SMTPConfig;
            _memoryCache = memoryCache;
        }
        [HttpPost("Email/CheckCodeForForgotPassword")]
        public async Task<Response> CheckCodeForForgotPassword(CheckCodeForForgotPasswordRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        [HttpPost("InSession/ChangeCurrentPassword")]
        public async Task<Response> ChangeCurrentPassword(ChangeCurrentPasswordRequest request)
        {
            var response = await _mediator.Send(request);
            return response;

        }

        [HttpGet("InSession/SendCodeToEmailForgotPassword")]
        public async Task<Response> ForgotPasswordInSession()
        {
            var userResponse = await _authManager.GetCurrentUser(User);
            if (userResponse.CurrentUser.Email == null || userResponse.CurrentUser.Email == "")
            {
                return new Response(400, false, "User don't have email address!");
            }
            var operation = await SendEmailAsync(userResponse.CurrentUser.Email);
            if (!operation == true)
            {
                return new Response(400, false, "Something error!");
            }
            return new Response(200, true, "We have sent a confirmation code to your email to change the password.");
        }
        [HttpPost("InSession/ChangeForgotPasswordInSession")]
        public async Task<Response> ChangeForgotPasswordInSession(ChangeForgotPasswordInSessionRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        [HttpPost("OutSession/ForgotPasswordEmail")]
        public async Task<Response> ForgotPasswordEmail(ForgotPasswordEmailRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        [HttpPost("OutSession/ChangeForgotPasswordOutSession")]
        public async Task<Response> ChangeForgotPasswordOutSession(ChangeForgotPasswordOutSessionRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        private async Task<bool> SendEmailAsync(string email)
        {
            if (_memoryCache.TryGetValue(email, out _))
            {
                return false;
            }

            int code = CodeHelper.GetRandomCode(7);
            var emailRequest = new EmailRequest()
            {
                Body = $"{code}",
                Subject = $"Ваш код для смены пароля: ",
                RecipientEmail = $"{email}",
            };
            await _emailService.SendEmailAsync(emailRequest, _config);
            _memoryCache.Set(email, code, DateTimeOffset.Now.AddMinutes(15));

            return true;
        }
    }
}
