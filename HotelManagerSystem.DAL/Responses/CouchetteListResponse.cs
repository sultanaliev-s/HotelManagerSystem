using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class CouchetteListResponse : Response
    {
        public CouchetteListResponse(int statusCode, bool success, string message, List<Couchette> couchette)
            : base(statusCode, success, message)
        {
            Couchette = couchette.Select(dep => new CouchetteDto(dep)).ToList();
        }

        public List<CouchetteDto> Couchette { get; set; }

    }
}