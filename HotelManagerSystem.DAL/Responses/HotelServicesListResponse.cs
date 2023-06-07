using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelServicesListResponse : Response
    {
        public HotelServicesListResponse(int statusCode, bool success, string message, List<HotelServices> hotels)
            : base(statusCode, success, message)
        {
            Hotels = hotels.Select(dep => new HotelServicesDto(dep)).ToList();
        }

        public List<HotelServicesDto> Hotels { get; set; }
    }
}