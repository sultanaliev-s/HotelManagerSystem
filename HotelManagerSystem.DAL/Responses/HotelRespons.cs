using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelRespons : Response
    {
        public HotelRespons(int statusCode, bool success, string message, Hotel hotel)
            : base(statusCode, success, message)
        {
            Hotel = new HotelDto(hotel);
        }
        public HotelDto Hotel { get; set; }
    }
}
