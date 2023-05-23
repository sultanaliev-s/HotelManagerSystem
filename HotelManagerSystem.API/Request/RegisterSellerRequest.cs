using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using HotelManagerSystem.API.Responses;
using MediatR;

namespace HotelManagerSystem.API.Request;

public class RegisterSellerRequest : IRequest<Response>
{
    [JsonIgnore] public string? UserId { get; set; }

    [Required] public int DepartmentId { get; set; }

    [Required] public int PassageId { get; set; }

    [Required] public int RowId { get; set; }

    [Required] public string PhoneNumber { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}