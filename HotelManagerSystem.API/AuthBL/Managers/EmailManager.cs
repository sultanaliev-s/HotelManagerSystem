using System.Security.Claims;
using DorgramApi.WebAPI.AuthBL.Models;
using HotelManagerSystem.API.AuthBL.Models;
using HotelManagerSystem.API.Configs;
using HotelManagerSystem.API.Handlers;
using HotelManagerSystem.API.Repositories;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.API.Service;
using HotelManagerSystem.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace HotelManagerSystem.API.AuthBL.Managers
{
    public class EmailManager
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly EmailService _emailService;
        private readonly SMTPConfig _config;
        private readonly UserManager<User> _userManager;
        public EmailManager(IMemoryCache memoryCache, IUserRepository userRepository, SignInManager<User> signInManager, EmailService emailService, Config config, UserManager<User> userManager)
        {
            _memoryCache = memoryCache;
            _userRepository = userRepository;
            _signInManager = signInManager;
            _emailService = emailService;
            _config = config.SMTPConfig;
            _userManager = userManager;
        }

        public async Task<Response> CheckCode(CheckCodeRequest request, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(request.Email, out int code) && code == request.Code)
            {
                if (!await _userRepository.UpdateUserEmailConfirmedFlag(request.Email))
                    return new Response(404, false, $"User with {request.Email} email was't found");

                var user = await _userRepository.GetUserByEmailAsync(request.Email);
                await _signInManager.SignInAsync(user, isPersistent: false);

                return new Response(200, true, "Code confirmed successfully");
            }
            else
            {
                return new Response(400, false, "Time of code validity expired, please reregister to get a new code");
            }
        }
        public async Task<bool> SendEmailAsync(string email)
        {
            if (_memoryCache.TryGetValue(email, out _))
            {
                return false;
            }

            int code = CodeHelper.GetRandomCode(7);
            var emailRequest = new EmailRequest()
            {
                Body = $"Ваш код верификации",
                Subject = $"{code}",
                RecipientEmail = $"{email}",
            };
            await _emailService.SendEmailAsync(emailRequest, _config);
            _memoryCache.Set(email, code, DateTimeOffset.Now.AddMinutes(15));

            return true;
        }
        public async Task<Unit> SendToEmailAsync(SendEmailCommand request, CancellationToken cancellationToken)
        {
            await _emailService.SendEmailAsync(request.EmailRequest, _config);

            return Unit.Value;
        }
        public async Task<Response> VerifyEmail(VerifyEmailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new Response(400, false, "User not found");
                throw new DException("User not found");
            }

            var verifiedPassword = _userManager
                .PasswordHasher
                .VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (verifiedPassword == 0)
            {
                return new Response(400, false, "Incorrect pasword");
                throw new DException("Incorrect password");
            }

            await SendEmailAsync(request.Email);
            return new Response(200, true, "Email will successfully verify");
        }
        public async Task<Response> ChangeEmail(ChangeEmailRequest request, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(request.OldEmail, out int code)
                && code == request.Code)
            {
                if (!await _userRepository.UpdateUserEmailAsync(request.OldEmail, request.NewEmail))
                {
                    return new Response(400, false, $"User with {request.OldEmail} email was't found");
                    throw new DException($"User with {request.OldEmail} email was't found");
                }

                return new Response(200, true, "Email sucessfully change");
            }
            else
            {
                return new Response
                    (400, false, "Time of code validity expired, please register to get a new code");
            }
        }
        public async Task<Response> ChangeEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new Response(400, false, "User not found");
                throw new DException("User not found");
            }

            await SendEmailAsync(email);
            return new Response(200, true, "User email will change");
        }
        public async Task<CurrentUserEmailResponse> GetCurrentUserEmailAsync(ClaimsPrincipal currentUserClaims)
        {
            var user = await _userManager.GetUserAsync(currentUserClaims);

            if (user == null)
            {
                return new CurrentUserEmailResponse(400, false, "Current user not found", null);
                throw new DException("User not found");
            }

            return new CurrentUserEmailResponse(200, true, "User recieved", user.Email);
        }

    }
}
