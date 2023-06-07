using HotelManagerSystem.Models.Common;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class HotelDto : EntityDto<int>
    {
        public HotelDto(Hotel entity) : base(entity)
        {
            Name = entity.Name;
            Description = entity.Description;
            ReviewStars = entity.ReviewStars;
            CheckingAccount = entity.CheckingAccount;
            IsOne = entity.IsOne;
            FilialCount = entity.FilialCount;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ReviewStars { get; set; }
        public bool IsOne { get; set; }
        public string CheckingAccount { get; set; }
        public int FilialCount { get; set; }


    }
}