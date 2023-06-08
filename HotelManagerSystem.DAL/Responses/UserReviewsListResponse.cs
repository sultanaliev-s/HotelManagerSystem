using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class UserReviewsListResponse : Response
    {
        public UserReviewsListResponse(int statusCode, bool success, string message, List<ClientReview> client)
          : base(statusCode, success, message)
        {
            Client =  client.Select(dep => new ReviewsDto(dep)).ToList();
        }
        public List<ReviewsDto> Client { get; set; }
    }
}