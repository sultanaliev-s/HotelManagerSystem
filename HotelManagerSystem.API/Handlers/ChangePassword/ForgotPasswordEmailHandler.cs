using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request.ChangePassword;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers.ChangePassword
{
    public class ForgotPasswordEmailHandler : IRequestHandler<ForgotPasswordEmailRequest, Response>
    {
        private readonly ChangePasswordManager _manager;

        public ForgotPasswordEmailHandler(ChangePasswordManager manager)
        {
            _manager = manager;
        }

        public async Task<Response> Handle(ForgotPasswordEmailRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.ForgotPasswordEmail(request, cancellationToken);
            return response;
        }
    }
}
