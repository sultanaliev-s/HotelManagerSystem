using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;

namespace HotelManagerSystem.DAL.Responses
{
    public class CountryResponse : Response
    {
        public CountryResponse(int statusCode, bool success, string message, Country country)
          : base(statusCode, success, message)
        {
            Country = new CountryDto(country);
        }
        public CountryDto Country { get; set; }
    }
}