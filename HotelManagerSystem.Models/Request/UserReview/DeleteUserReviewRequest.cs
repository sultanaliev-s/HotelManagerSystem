namespace HotelManagerSystem.Models.Request.UserReview
{
    public class DeleteUserReviewRequest
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }
}