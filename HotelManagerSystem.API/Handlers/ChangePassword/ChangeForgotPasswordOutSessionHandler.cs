using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request.ChangePassword;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers.ChangePassword
{
    public class ChangeForgotPasswordOutSessionHandler : IRequestHandler<ChangeForgotPasswordOutSessionRequest, Response>
    {
        private readonly ChangePasswordManager _manager;
        public ChangeForgotPasswordOutSessionHandler(ChangePasswordManager manager)
        {
            _manager = manager;
        }

        public async Task<Response> Handle(ChangeForgotPasswordOutSessionRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.ChangeForgotPasswordOutSession(request, cancellationToken);   
            return response;
        }
    }
}
