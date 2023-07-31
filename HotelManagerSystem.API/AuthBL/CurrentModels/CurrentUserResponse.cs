using HotelManagerSystem.DAL.AuthBL.CurrentModels;
using HotelManagerSystem.DAL.Responses;

namespace HotelManagerSystem.API.AuthBL.CurrentModels
{
    public class CurrentUserResponse : Response
    {
        public UserViewModel CurrentUser { get; set; }

        public CurrentUserResponse(int statusCode, bool success, string message, UserViewModel user) : base(statusCode, success, message)
        {
            CurrentUser = user;
        }
    }
}
