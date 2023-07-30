using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.EntityDto;

namespace HotelManagerSystem.Models.DTOs
{
    public class ReviewDto : EntityDto<int>
    {
        public ReviewDto(ClientReview entity) : base(entity)
        {
            Stars = entity.Stars;
            Comment = entity.Comment;
        }

        public int Stars { get; set; }
        public string Comment { get; set; }

    }
}