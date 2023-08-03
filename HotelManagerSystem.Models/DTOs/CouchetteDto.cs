using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class CouchetteDto : EntityDto<int>
    {
        public CouchetteDto(Couchette entity) : base(entity)
        {
            Name = entity.Name;
        }
        public string Name { get; set; }
    }
}