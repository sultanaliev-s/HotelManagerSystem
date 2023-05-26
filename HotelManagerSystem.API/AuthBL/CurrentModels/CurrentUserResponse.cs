using HotelManagerSystem.API.AuthBL.CurrentModels;
using HotelManagerSystem.API.Responses;

namespace HotelManagerSystem.WebAPI.AuthBL.CurrentModels
{
    public class CurrentUserResponse : Response
    {
        public CurrentUserResponse(int statusCode, bool success, string message, UserViewModel user) : base(statusCode, success, message)
        {
            CurrentUser = user;
        }

        public UserViewModel CurrentUser { get; set; }
    }
}
