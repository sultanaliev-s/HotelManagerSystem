using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, Response>
    {
        private readonly AuthManager _manager;


        public RegisterUserHandler(AuthManager manager)
        {
            _manager = manager;
        }

        public async Task<Response> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.RegisterUser(request, cancellationToken);
            return response;
        }
    }
}
