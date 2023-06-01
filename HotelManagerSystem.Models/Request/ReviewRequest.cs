using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.Models.Request
{
    public class ReviewRequest
    {
        public List<ClientReview> Reviews { get; set; }
        public int hotelId { get; set; }
    }
}