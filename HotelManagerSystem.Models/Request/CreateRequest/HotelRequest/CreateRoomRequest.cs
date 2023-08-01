using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.Models.Request.CreateRequest.HotelRequest
{
    public class CreateRoomRequest
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int RoomAmount { get; set; }
        public bool Smoke { get; set; }
        public decimal Price { get; set; }
        public int BasePerson { get; set; }
        public int RoomTypeId { get; set; }
    }
}