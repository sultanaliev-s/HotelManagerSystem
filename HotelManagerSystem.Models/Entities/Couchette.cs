using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class Couchette : BaseEntity<int>
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}