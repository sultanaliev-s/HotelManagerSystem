using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelServicesResponse : Response
    {
        public HotelServicesResponse(int statusCode, bool success, string message, HotelServices hotel)
          : base(statusCode, success, message)
        {
            Hotel = new HotelServicesDto(hotel);
        }
        public HotelServicesDto Hotel { get; set; }
    }
}