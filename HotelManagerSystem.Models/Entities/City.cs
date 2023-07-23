using HotelManagerSystem.Models.Common;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.Models.Data
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Hotel> Hotels { get; set; }

    }
}
