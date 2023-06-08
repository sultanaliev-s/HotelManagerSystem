using HotelManagerSystem.Models.Common;

namespace HotelManagerSystem.Models.Entities.Relations
{
    public class HotelsServices : BaseEntity<int> 
    {
        public int ServiceId { get; set; }
        public int HotelId { get; set; } 
    }
}