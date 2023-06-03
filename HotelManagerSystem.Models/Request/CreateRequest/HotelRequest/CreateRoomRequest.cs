using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.Models.Request.CreateRequest.HotelRequest
{
    public class CreateRoomRequest
    {
        public int hotelId { get; set; }
        public string Name { get; set; }
        public int RoomAmount { get; set; }
        public bool Smoke { get; set; }
        public decimal Price { get; set; }
        public int BasePerson { get; set; }
        public int RoomTypeId { get; set; }
        public int CouchetteId { get; set; }

        public CreateRoomRequest(int id, string name, int amount, bool smoke, decimal price, int person,
            int type, int couchette)
        {
            hotelId = id;
            Name = name;
            RoomAmount = amount;
            Smoke = smoke;
            Price = price;
            BasePerson = person;
            RoomTypeId = type;
            CouchetteId = couchette;

        }

    }
}