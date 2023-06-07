using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class UserReviewsListResponse : Response
    {
        public UserReviewsListResponse(int statusCode, bool success,  string message, List<ClientReview> reviews)
          : base(statusCode, success, message)
        {
            Reviews = reviews.Select(dep => new ReviewsDto(dep)).ToList();
        }

        public List<ReviewsDto> Reviews { get; set; }
    }
}