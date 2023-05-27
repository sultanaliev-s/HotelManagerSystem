using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class ClientReview : BaseEntity<int>
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int Stars { get; set; }
        public string Comment { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}