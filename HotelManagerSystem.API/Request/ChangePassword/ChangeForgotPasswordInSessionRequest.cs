using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request.ChangePassword;

public class ChangeForgotPasswordInSessionRequest : IRequest<Response>
{
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}