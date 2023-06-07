using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;
using System.ComponentModel;

namespace HotelManagerSystem.Models.DTOs
{
    public class HotelCategoryDto : EntityDto<int>
    {

        public HotelCategoryDto(HotelCategory entity) : base(entity)
        {
            Name = entity.Name;
            Description = entity.Description;
            ParentId = entity.HotelTypeId;

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
    }
}