using DorgramApi.WebAPI.AuthBL.Models;
using HotelManagerSystem.API.AuthBL.CurrentModels;
using HotelManagerSystem.API.Configs;
using HotelManagerSystem.API.Request.ChangePassword;
using HotelManagerSystem.API.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace HotelManagerSystem.API.AuthBL.Managers
{
    public class ChangePasswordManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signInManager;
        private readonly IMemoryCache _memoryCache;
        private readonly SMTPConfig _config;
        private readonly EmailManager _emailManager;

        public ChangePasswordManager(UserManager<User> userManager, IMediator mediator, IHttpContextAccessor httpContextAccessor
            , SignInManager<User> signInManager, IMemoryCache memoryCache
            ,Config config, EmailManager emailManager)
        {
            _userManager = userManager;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _memoryCache = memoryCache;
            _config = config.SMTPConfig;
            _emailManager = emailManager;
        }
        public async Task<Response> ChangeCurrentPassword(ChangeCurrentPasswordRequest request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var currentUser = await _userManager.GetUserAsync(httpContext.User);
            var result = await _userManager.ChangePasswordAsync(currentUser, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                return new Response(400, false, "Не получилось сменить пароль, перепроверьте введенные данные!");
            }
            await _signInManager.RefreshSignInAsync(currentUser);
            return new Response(200, false, "Вы успешно сменили пароль, перезайдите в систему!");
        }
        public async Task<Response> ChangeForgotPasswordInSession(ChangeForgotPasswordInSessionRequest request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var currentUser = await _userManager.GetUserAsync(httpContext.User);
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return new Response(400, false, "Passwords do not match!");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(currentUser);

            var result = await _userManager.ResetPasswordAsync(currentUser, token, request.NewPassword);
            if (!result.Succeeded)
            {
                return new Response(400, false, "Failed to reset password");
            }
            return new Response(200, true, "Password reset successfully!");
        }
        public async Task<Response> ChangeForgotPasswordOutSession(ChangeForgotPasswordOutSessionRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return new Response(400, false, "Passwords do not match!");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
            if (!result.Succeeded)
            {
                return new Response(400, false, "Failed to reset password");
            }
            return new Response(200, true, "Password reset successfully!");
        }
        public async Task<Response> CheckCodeForForgotPassword(CheckCodeForForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(request.Email, out int code) && code == request.Code)
            {
                _memoryCache.Remove(request.Email);
                return new Response(200, true, "Code confirmed successfully");
            }
            else
            {
                return new Response(400, false, "Time of code validity expired, please reregister to get a new code");
            }
        }
        public async Task<Response> ForgotPasswordEmail(ForgotPasswordEmailRequest request, CancellationToken cancellationToken)
        {
            if (request.Email == null || request.Email == "")
            {
                return new Response(400, false, "Email adress don't be a null!");
            }
            var operation = await _emailManager.SendEmailAsync(request.Email);
            if (!operation == true)
            {
                return new Response(400, false, "Something error!");
            }
            return new Response(200, true, "We have sent a confirmation code to your email to change the password.");
        }

    }
}
