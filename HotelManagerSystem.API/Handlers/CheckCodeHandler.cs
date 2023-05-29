using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.DAL.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers
{
    public class CheckCodeHandler : IRequestHandler<CheckCodeRequest, Response>
    {
        private readonly EmailManager _emailManager;
        public CheckCodeHandler(EmailManager emailManager)
        {
            _emailManager = emailManager;
        }

        public async Task<Response> Handle(CheckCodeRequest request, CancellationToken cancellationToken)
        {
            var response = await _emailManager.CheckCode(request, cancellationToken);
            if (response != null) 
            {
                return new Response(400, false, "Time of code validity expired, please reregister to get a new code");
            }
            return new Response(400, false, "Wrong request!");
        }
    }
}
