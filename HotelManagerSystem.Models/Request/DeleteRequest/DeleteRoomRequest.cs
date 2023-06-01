namespace HotelManagerSystem.Models.Request.DeleteRequest
{
    public class DeleteRoomRequest
    {
        public string Name { get; set; }
        public int RoomAmount { get; set; }
        public bool Smoke { get; set; }
        public decimal Price { get; set; }
        public int BasePerson { get; set; }
        public int RoomTypeId { get; set; }
        public int CouchetteId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}