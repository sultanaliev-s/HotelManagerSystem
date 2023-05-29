using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.DAL.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, AuthResponse>
    {
        private readonly AuthManager _manager;

        public LoginUserHandler(AuthManager manager)
        {
            _manager = manager;
        }
        public async Task<AuthResponse> Handle(LoginUserRequest request, CancellationToken token)
        {
            var response = await _manager.LoginUser(request, token);
            return response;
        }
    }
}
