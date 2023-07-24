namespace HotelManagerSystem.Models.Request.CreateRequest
{
    public class CreateIdNameDirectoryRequest
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}