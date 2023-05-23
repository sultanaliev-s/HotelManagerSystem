using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request.ChangePassword;

public class ForgotPasswordEmailRequest : IRequest<Response>
{
    public string Email { get; set; }
}