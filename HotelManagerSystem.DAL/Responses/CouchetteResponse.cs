using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class CouchetteResponse : Response
    {
        public CouchetteResponse(int statusCode, bool success, string message, Couchette couchette)
          : base(statusCode, success, message)
        {
            Couchette = new CouchetteDto(couchette);
        }
        public CouchetteDto Couchette { get; set; }
    }
}