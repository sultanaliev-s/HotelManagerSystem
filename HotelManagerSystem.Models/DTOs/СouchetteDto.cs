using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class СouchetteDto : EntityDto<int>
    {
        public СouchetteDto(Couchette entity) : base(entity)
        {
            Name = entity.Name;
            RoomId = entity.RoomId;
        }
        public string Name { get; set; }
        public int RoomId { get; set; }
    }
}