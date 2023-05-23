
namespace HotelManagerSystem.API.Responses
{
    public class AuthResponse : Response
    {
        public AuthResponse(int statusCode, bool success, string message, string fullName, string accessToken, string refreshToken) : base(statusCode, success, message)
        {
            FullName = fullName;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
        public string FullName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
