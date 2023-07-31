using HotelManagerSystem.DAL.Responses;


namespace HotelManagerSystem.API.Responses
{
    public class AuthResponse : Response
    {
        public TokenResponse TokenResponse { get; set; }

        public AuthResponse(
            int statusCode,
            bool success,
            string message,
            string fullName,
            string accessToken,
            string refreshToken) : base(statusCode, success, message)
        {
            TokenResponse = new TokenResponse(fullName, accessToken, refreshToken);
        }
    }
}
