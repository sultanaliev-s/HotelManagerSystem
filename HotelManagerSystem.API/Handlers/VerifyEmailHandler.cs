using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers
{
    public class VerifyEmailHandler : IRequestHandler<VerifyEmailRequest, Response>
    {
        private readonly EmailManager _manager;
        public VerifyEmailHandler(EmailManager manager)
        {
            _manager = manager;
        }
        public async Task<Response> Handle(VerifyEmailRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.VerifyEmail(request, cancellationToken);
            return response;
        }
    }
}
