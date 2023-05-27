namespace HotelManagerSystem.Models.Request
{
    public class DeleteNameDirectoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}