using HotelManagerSystem.Models.Common;

namespace HotelManagerSystem.Models.Entities
{
    public class ErrorLog : BaseEntity<int>
    {
        public string ConnecrionString { get; set; }
        public string[] LoogFiles { get; set; }
        public string LogTable { get; set; }

    }
}