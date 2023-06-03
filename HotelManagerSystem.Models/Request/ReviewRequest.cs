using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.Models.Request
{
    public class ReviewRequest
    {
        public int HotelId { get; set; }
        public List<ClientReview> Reviews { get; set; }

        public ReviewRequest(int id, List<ClientReview> reviews)
        {
            HotelId = id;
            Reviews = reviews;
        }
    }
}