namespace HotelManagerSystem.Models.Request
{
    public class CreateNameDirectoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}