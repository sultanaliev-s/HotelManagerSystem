using HotelManagerSystem.API.AuthBL.Models;
using HotelManagerSystem.API.Responses;

namespace DorgramApi.WebAPI.AuthBL.Models
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
