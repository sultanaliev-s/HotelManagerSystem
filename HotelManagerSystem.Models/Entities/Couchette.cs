using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class Couchette : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

    }
}