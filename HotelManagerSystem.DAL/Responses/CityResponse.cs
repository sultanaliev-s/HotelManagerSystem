using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class CityResponse : Response
    {
        public CityResponse(int statusCode, bool success, string message, City city)
           : base(statusCode, success, message)
        {
            City = new CityDto(city);
        }
        public CityDto City { get; set; }
    }
}