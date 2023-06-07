using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelTypeResponse : Response
    {
        public HotelTypeResponse(int statusCode, bool success, string message, HotelType hotel)
          : base(statusCode, success, message)
        {
            Hotel = new HotelTypeDto(hotel);
        }
        public HotelTypeDto Hotel { get; set; }
    }
}