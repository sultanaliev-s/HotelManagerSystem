namespace HotelManagerSystem.Models.Request.UserReview
{
    public class CreateUserReviewRequest
    {
        public int HotelId { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }
}