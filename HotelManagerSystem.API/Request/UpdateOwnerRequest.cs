namespace HotelManagerSystem.API.Request;

public class UpdateOwnerRequest
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}