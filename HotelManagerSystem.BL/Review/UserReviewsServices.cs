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
        private readonly IRepository<Hotel, int> _hotelRepository;
        public UserReviewsServices(IRepository<ClientReview, int> userReviewRepository, IRepository<Hotel, int> hotelRepository)
        {
            _repository = userReviewRepository;
            _hotelRepository = hotelRepository;
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
            if (request.Stars < 0 || request.Stars > 10)
            {
                throw new BadRequestException("Stars should be from 0 to 10");
            }

            ClientReview review = new()
            {
                UserId = userId,
                HotelId = request.HotelId,
                Stars = request.Stars,
                Comment = request.Comment,
                UpdatedDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow
            };

            var created = await _repository.AddAsync(review);

            var rating = await HotelStars(request.HotelId);

            var hotel = await _hotelRepository.GetByIdAsync(request.HotelId);
            hotel.ReviewStars = rating;

            await _hotelRepository.UpdateAsync(hotel);
            return created.Id;
        }

        public async Task Delete(int id)
        {
            var hotelId = (await _repository.GetByIdAsync(id)).HotelId;
            var hotel = await _hotelRepository.GetByIdAsync(hotelId);

            await _repository.DeleteByIdAsync(id);

            var rating = await HotelStars(hotelId);
            hotel.ReviewStars = rating;

            await _hotelRepository.UpdateAsync(hotel);

        }

        public async Task<decimal> HotelStars(int hotelId)
        {
            var reviews = await _repository.GetByPredicate(x => x.HotelId == hotelId);

            var sumOfStars = reviews.Select(x => x.Stars).Sum();
            var reviewsCount = (decimal)reviews.Count;

            var average = Math.Round((decimal)(sumOfStars / reviewsCount), 2);
            return average;
        }
    }
}