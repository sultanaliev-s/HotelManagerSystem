using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request.ChangePassword;

public class ChangeCurrentPasswordRequest : IRequest<Response>
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}