namespace HotelManagerSystem.API.Responses
{
    public class TokenResponse
    {
        public string FullName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public TokenResponse(
            string fullName,
            string accessToken,
            string refreshToken)
        {
            FullName = fullName;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
