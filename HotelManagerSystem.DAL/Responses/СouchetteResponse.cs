using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class СouchetteResponse : Response
    {
        public СouchetteResponse(int statusCode, bool success, string message, Сouchette couchette)
          : base(statusCode, success, message)
        {
            Сouchette = new СouchetteDto(couchette);
        }
        public СouchetteDto Сouchette { get; set; }
    }
}