using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class RoomTypesListresponse : Response
    {
        public RoomTypesListresponse(int statusCode, bool success, string message, List<RoomType> room)
            : base(statusCode, success, message)
        {
            Room = room.Select(dep => new RoomTypeDto(dep)).ToList();
        }

        public List<RoomTypeDto> Room { get; set; }

    }
}