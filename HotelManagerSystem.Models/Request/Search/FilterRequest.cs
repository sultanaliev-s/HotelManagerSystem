namespace HotelManagerSystem.Models.Request.Search
{
    public class FilterRequest
    {
        public int? CityId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int Persons { get; set; }
    }
}
