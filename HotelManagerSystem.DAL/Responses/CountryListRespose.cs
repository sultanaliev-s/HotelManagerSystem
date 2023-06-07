using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;

namespace HotelManagerSystem.DAL.Responses
{
    public class CountryListRespose : Response
    {
        public CountryListRespose(int statusCode, bool success, string message, List<Country> countries)
            : base(statusCode, success, message)
        {
            Countries = countries.Select(dep => new CountryDto(dep)).ToList();
        }

        public List<CountryDto> Countries { get; set; }
    }
}