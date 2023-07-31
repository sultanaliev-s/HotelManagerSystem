using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.Common;
using HotelManagerSystem.DAL.Responses;
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
            Response response;
            try
            {
                response = await _manager.RegisterUser(request, cancellationToken);
            }
            catch (DException ex)
            {
                return new Response(400, false, ex.Message);
            }
            return response;
        }
    }
}
