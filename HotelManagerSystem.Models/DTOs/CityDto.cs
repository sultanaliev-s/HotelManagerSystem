using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class CityDto : EntityDto<int>
    {
        public CityDto(City entity) : base(entity)
        {
            Name = entity.Name;
            CountryId = entity.CountryId;
            HotelId = entity.HotelId;
        }

        public string Name { get; set; }
        public int CountryId { get; set; }
        public int HotelId { get; set; }

    }
}
