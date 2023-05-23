using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request.ChangePassword;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers.ChangePassword
{
    public class ChangeForgotPasswordInSessionHandler : IRequestHandler<ChangeForgotPasswordInSessionRequest, Response>
    {
        private readonly ChangePasswordManager _manager;

        public ChangeForgotPasswordInSessionHandler(ChangePasswordManager manager)
        {
            _manager = manager;
        }
        public async Task<Response> Handle(ChangeForgotPasswordInSessionRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.ChangeForgotPasswordInSession(request, cancellationToken);
            return response;
        }
    }
}
