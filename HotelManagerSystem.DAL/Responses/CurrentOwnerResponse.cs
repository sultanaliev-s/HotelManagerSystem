using HotelManagerSystem.Models.Entities.ModelOwner;

namespace HotelManagerSystem.DAL.Responses;

public class CurrentOwnerResponse
{
    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public OwnerViewModel Owner { get; set; }
}