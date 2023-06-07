using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class СouchetteListResponse : Response
    {
        public СouchetteListResponse(int statusCode, bool success, string message, List<Сouchette> couchette)
            : base(statusCode, success, message)
        {
            Сouchette = couchette.Select(dep => new СouchetteDto(dep)).ToList();
        }

        public List<СouchetteDto> Сouchette { get; set; }

    }
}