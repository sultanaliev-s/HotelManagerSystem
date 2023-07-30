using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.UserReview;

namespace HotelManagerSystem.BL.Review
{
    public class UserReviewsServices
    {
        private readonly IRepository<ClientReview, int> _repository;
        public UserReviewsServices(IRepository<ClientReview, int> userReviewRepository)
        {
            _repository = userReviewRepository;
        }

        public async Task<List<ReviewDto>> GetAllForHotel(int hotelId)
        {
            var reviews = await _repository.GetByPredicate(x => x.HotelId == hotelId);
            return reviews
                .Select(x => new ReviewDto(x))
                .ToList();
        }

        public async Task<ReviewDto> GetByIdAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null)
            {
                throw new EntityNotFoundException<ClientReview>();
            }
            return new ReviewDto(review);
        }

        public async Task<int> Create(CreateUserReviewRequest request, string userId)
        {
            if (request.Stars < 0 || request.Stars > 5)
            {
                throw new BadRequestException("Stars should be from 0 to 5");
            }

            ClientReview review = new()
            {
                UserId = userId.ToString(),
                HotelId = request.HotelId,
                Stars = request.Stars,
                Comment = request.Comment,
                UpdatedDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow
            };

            var created = await _repository.AddAsync(review);

            return created.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<int> HotelStars(int hotelId)
        {
            var reviews = await _repository.GetByPredicate(x => x.HotelId == hotelId);

            var sumOfStars = reviews.Select(x => x.Stars).Sum();
            var reviewsCount = reviews.Count;

            var average = sumOfStars / reviewsCount;
            return average;
        }
    }
}