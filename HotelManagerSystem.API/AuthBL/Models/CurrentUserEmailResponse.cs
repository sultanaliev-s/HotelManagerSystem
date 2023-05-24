using System.ComponentModel.DataAnnotations;
using HotelManagerSystem.API.Responses;

namespace HotelManagerSystem.API.AuthBL.Models
{
    public class CurrentUserEmailResponse : Response
    {
        public CurrentUserEmailResponse(int statusCode, bool success, string message, string email)
            : base(statusCode, success, message)
        {
            Email = email;
        }
        [Required]
        public string Email { get; set; }
    }
}
