using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class CityDto : EntityDto<int>
    {
        public CityDto(City entity) : base(entity)
        {
            Name = entity.Name;
            CountryId = entity.CountryId;
        }

        public string Name { get; set; }
        public int CountryId { get; set; }

    }
}
