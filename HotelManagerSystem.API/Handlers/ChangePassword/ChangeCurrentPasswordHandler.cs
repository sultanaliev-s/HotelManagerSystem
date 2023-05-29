using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Request.ChangePassword;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.DAL.Responses;
using MediatR;

namespace HotelManagerSystem.API.Handlers.ChangePassword
{
    public class ChangeCurrentPasswordHandler : IRequestHandler<ChangeCurrentPasswordRequest, Response>
    {
        private readonly ChangePasswordManager _manager;

        public ChangeCurrentPasswordHandler(ChangePasswordManager manager)
        {
            _manager = manager;
        }

        public async Task<Response> Handle(ChangeCurrentPasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await _manager.ChangeCurrentPassword(request, cancellationToken);
            return response;
        }
    }
}
