using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.DAL.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request;

public class ChangeEmailRequest : IRequest<Response>
{
    [Required] public string NewEmail { get; set; }

    [Required] public string OldEmail { get; set; }

    [Required] public int Code { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}