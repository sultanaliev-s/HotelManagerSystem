namespace HotelManagerSystem.Models.Request.UpdateRequest
{
    public class UpdateIdDescDirectoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}