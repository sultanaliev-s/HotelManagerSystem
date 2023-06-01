using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.Models.Request.UserReview;

namespace HotelManagerSystem.BL.Review
{
    public class UserReviewsServices
    {
        private readonly IRepository<ClientReview, int> _repository;
        private readonly HotelContext _context;
        public UserReviewsServices(IRepository<ClientReview, int> userReviewRepository, HotelContext context)
        {
            _repository = userReviewRepository;
            _context = context;
        }

        public async Task<List<ClientReview>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ClientReview> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Response> Create(CreateUserReviewRequest request)
        {
            ClientReview review = new ClientReview()
            {
                Stars = request.Stars,
                Comment = request.Comment,
                CreatedUtc = DateTime.Now

            };

            _repository.AddAsync(review);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
        public async Task<int> HotelStars(List<ClientReview> reviews, int hotelId)
        {
            var stars = from r in reviews
                        where r.HotelId == hotelId
                        select r.Stars;

            int sum = stars.Sum();

            int reviewsCount = reviews.Count();

            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == hotelId);

            hotel.ReviewStars = (sum / reviewsCount);

            return hotel.ReviewStars;

        }

    }
}