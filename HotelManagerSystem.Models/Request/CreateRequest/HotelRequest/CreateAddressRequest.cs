using HotelManagerSystem.Models.Data;

namespace HotelManagerSystem.Models.Request.CreateRequest.HotelRequest
{
    public class CreateAddressRequest
    {
        public int HotelId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public DateTime CreateDate { get; set; }
    }
}