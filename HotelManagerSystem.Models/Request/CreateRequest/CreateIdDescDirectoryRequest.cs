namespace HotelManagerSystem.Models.Request.CreateRequest
{
    public class CreateIdDescDirectoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}