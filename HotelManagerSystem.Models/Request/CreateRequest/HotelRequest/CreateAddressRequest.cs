using HotelManagerSystem.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HotelManagerSystem.Models.Request.CreateRequest.HotelRequest
{
    public class CreateAddressRequest
    {
        public int Hotel{ get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public CreateAddressRequest(int id , int countryId, int cityId, string street, string number)
        {
            Hotel = id;
            CountryId= countryId;
            CityId= cityId;
            Street= street;
            StreetNumber= number;
        }
    }
}