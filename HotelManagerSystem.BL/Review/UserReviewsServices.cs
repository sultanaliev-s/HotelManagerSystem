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
        private readonly IRepository<Hotel, int> _repositoryHotel;
        public UserReviewsServices(IRepository<ClientReview, int> userReviewRepository, IRepository<Hotel, int> repositoryHotel)
        {
            _repository = userReviewRepository;
            _repositoryHotel = repositoryHotel;
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
        public async Task<Response> HotelStars(List<ClientReview> reviews, int hotelId)
        {
            int starsSum = reviews.Sum(review => review.Stars);

            int reviewsCount = reviews.Count();
            


            return new Response(200, true, null);

        }

    }
}