using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class CityListResponse : Response
    {
        public CityListResponse(int statusCode, bool success, string message, List<City> cities)
           : base(statusCode, success, message)
        {
            City = cities.Select(dep => new CityDto(dep)).ToList();
        }

        public List<CityDto> City { get; set; }
    }
}