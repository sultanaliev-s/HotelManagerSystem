namespace HotelManagerSystem.Models.Request.CreateRequest
{
    public class CreateIdDescDirectoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int HotelTypeId { get; set; }
    }
}