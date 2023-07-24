using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;

namespace HotelManagerSystem.DAL.Responses
{
    public class CountryResponse
    {
        public CountryResponse(Country country)
        {
            Country = new CountryDto(country);
        }
        public CountryDto Country { get; set; }
    }
}