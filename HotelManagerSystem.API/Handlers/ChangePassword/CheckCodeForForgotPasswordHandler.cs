using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request.ChangePassword;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers.ChangePassword
{
    public class CheckCodeForForgotPasswordHandler : IRequestHandler<CheckCodeForForgotPasswordRequest, Response>
    {
        private readonly ChangePasswordManager _manager;

        public CheckCodeForForgotPasswordHandler(ChangePasswordManager manager)
        {
            _manager = manager;
        }

        public async Task<Response> Handle(CheckCodeForForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.CheckCodeForForgotPassword(request, cancellationToken);
            return response;
        }
    }
}
