using HotelManagerSystem.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HotelManagerSystem.Models.Request.Search
{
    public class FilterRequest
    {
        public int? CityId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int Persons { get; set; }

        public FilterRequest(int? city, DateTime? start, DateTime? end)
        {
            CityId = city;
            startDate= start;
            endDate = end;
        }
    }
}
