using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request;

public class VerifyEmailRequest : IRequest<Response>
{
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}