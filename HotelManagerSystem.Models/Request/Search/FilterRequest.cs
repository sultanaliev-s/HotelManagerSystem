namespace HotelManagerSystem.Models.Request.Search
{
    public class FilterRequest
    {
        public string City { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int Persons { get; set; }
    }
}
