using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelCategoryResponse : Response
    {
        public HotelCategoryResponse(int statusCode, bool success, string message, HotelCategory category)
            : base(statusCode, success, message)
        {
            Category = new HotelCategoryDto(category);
        }
        public HotelCategoryDto Category { get; set; }
    }
}