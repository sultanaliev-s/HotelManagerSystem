namespace HotelManagerSystem.Models.Request.Search
{
    public class SearchRequest
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}