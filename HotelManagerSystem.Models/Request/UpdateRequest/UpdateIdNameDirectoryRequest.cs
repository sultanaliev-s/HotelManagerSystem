namespace HotelManagerSystem.Models.Request.UpdateRequest
{
    public class UpdateIdNameDirectoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}