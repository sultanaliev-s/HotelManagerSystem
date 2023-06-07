using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class HotelTypeDto : EntityDto<int>
    {
        public HotelTypeDto(HotelType entity) : base(entity)
        {
            Name = entity.Name;
        }

        public string Name { get; set; }
    }
}