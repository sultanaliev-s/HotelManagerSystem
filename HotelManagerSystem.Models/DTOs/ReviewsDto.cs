using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class ReviewsDto : EntityDto<int>
    {
        public ReviewsDto(ClientReview entity) : base(entity)
        {
            Stars = entity.Stars;
            Comment= entity.Comment;
        }

        public int Stars { get; set; }
        public string Comment { get; set; }

    }
}