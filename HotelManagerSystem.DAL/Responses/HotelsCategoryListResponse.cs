using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelsCategoryListResponse : Response
    {
        public HotelsCategoryListResponse(int statusCode, bool success, string message, List<HotelCategory> hotels)
            : base(statusCode, success, message)
        {
            Hotels = hotels.Select(dep => new HotelCategoryDto(dep)).ToList();
        }

        public List<HotelCategoryDto> Hotels { get; set; }
    }
}