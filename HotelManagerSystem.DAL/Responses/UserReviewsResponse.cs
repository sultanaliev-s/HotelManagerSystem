using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class UserReviewsResponse : Response
    {
        public UserReviewsResponse(int statusCode, bool success, string message, ClientReview review)
            : base(statusCode, success, message)
        {
            Review = new ReviewsDto(review);
        }
        public ReviewsDto Review { get; set; }
    }
}