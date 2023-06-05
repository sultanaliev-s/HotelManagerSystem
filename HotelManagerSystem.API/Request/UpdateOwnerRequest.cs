namespace HotelManagerSystem.API.Request;

public class UpdateOwnerRequest
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}