using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class RoomTypeResponse : Response
    {
        public RoomTypeResponse(int statusCode, bool success, string message, RoomType room)
          : base(statusCode, success, message)
        {
            Room = new RoomTypeDto(room);
        }
        public RoomTypeDto Room { get; set; }
    }
}