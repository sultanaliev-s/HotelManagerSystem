using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using System.Linq;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelTypesListResponse : Response
    {
        public HotelTypesListResponse(int statusCode, bool success, string message,  List<HotelType> hotels)
            : base(statusCode, success, message)
        {
            Hotel = hotels.Select(dep => new HotelTypeDto(dep)).ToList();
        }

        public List<HotelTypeDto> Hotel { get; set; }
    }
}