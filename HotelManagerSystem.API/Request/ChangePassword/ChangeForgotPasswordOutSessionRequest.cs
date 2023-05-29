using HotelManagerSystem.API.Responses;
using HotelManagerSystem.DAL.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request.ChangePassword;

public class ChangeForgotPasswordOutSessionRequest : IRequest<Response>
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}