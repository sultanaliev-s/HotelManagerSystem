namespace HotelManagerSystem.API.Request;

public class RegisterOwnerRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}