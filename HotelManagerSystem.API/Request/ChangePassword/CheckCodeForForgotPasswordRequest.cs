using System.ComponentModel.DataAnnotations;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request.ChangePassword;

public class CheckCodeForForgotPasswordRequest : IRequest<Response>
{
    [Required] public string? Email { get; set; }

    [Required] public int? Code { get; set; }
}