using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;

namespace HotelManagerSystem.DAL.Responses
{
    public class CountryListRespose
    {
        public CountryListRespose(List<Country> countries)
        {
            Countries = countries.Select(dep => new CountryDto(dep)).ToList();
        }

        public List<CountryDto> Countries { get; set; }
    }
}