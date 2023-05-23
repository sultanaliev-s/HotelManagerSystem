using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers
{
    public class ConfirmChangeEmailHandler : IRequestHandler<ChangeEmailRequest, Response>
    {
        private readonly EmailManager _manager;

        public ConfirmChangeEmailHandler(EmailManager manager)
        {
            _manager = manager;
        }

        public async Task<Response> Handle(ChangeEmailRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.ChangeEmail(request, cancellationToken);
            return response;
        }
    }
}





