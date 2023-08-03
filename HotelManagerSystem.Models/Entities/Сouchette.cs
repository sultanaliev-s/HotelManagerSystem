using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class Сouchette : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

    }
}