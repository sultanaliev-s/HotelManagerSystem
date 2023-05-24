using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using MediatR;

namespace HotelManagerSystem.API.Request;

public class EmailRequest : IRequest
{
    [Required] public string RecipientEmail { get; set; }

    [Required] public string Subject { get; set; }

    [Required] public string Body { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}