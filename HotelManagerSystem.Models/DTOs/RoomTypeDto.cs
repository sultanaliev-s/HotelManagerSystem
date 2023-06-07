using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class RoomTypeDto : EntityDto<int>
    {
        public RoomTypeDto(RoomType entity) : base(entity)
        {
            Name = entity.Name;
        }

        public string Name { get; set; }
    }
}