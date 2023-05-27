namespace HotelManagerSystem.Models.Request
{
    public class UpdateNameDirectoryRequest
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}