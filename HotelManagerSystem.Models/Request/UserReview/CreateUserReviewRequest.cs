namespace HotelManagerSystem.Models.Request.UserReview
{
    public class CreateUserReviewRequest
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}