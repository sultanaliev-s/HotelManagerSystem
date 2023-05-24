using HotelManagerSystem.Models.Data;

namespace HotelManagerSystem.Models.Entities
{
    public class ClientReview : BaseEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int Stars { get; set; }
        public string Comment { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}