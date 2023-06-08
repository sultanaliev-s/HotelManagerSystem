using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class UserReviewsResponse : Response
    {
        public UserReviewsResponse(int statusCode, bool success, string message, ClientReview client)
          : base(statusCode, success, message)
        {
            Client = new ReviewsDto(client) ;
        }
        public ReviewsDto Client { get; set; }
    }
}