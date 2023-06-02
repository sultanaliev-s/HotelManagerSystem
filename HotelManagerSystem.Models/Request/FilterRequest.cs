using HotelManagerSystem.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HotelManagerSystem.Models.Request
{
    public class FilterRequest
    {
        public string City { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int Persons { get; set; }
    }
}
