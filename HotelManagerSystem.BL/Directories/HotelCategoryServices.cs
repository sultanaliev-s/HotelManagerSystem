using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.Models.Request.UserReview;

namespace HotelManagerSystem.BL.Directories
{
    public class HotelCategoryServices
    {
        private readonly IRepository<HotelCategory, int> _repository;

        public HotelCategoryServices(IRepository<HotelCategory, int> hotelCategoryRepository)
        {
            _repository = hotelCategoryRepository;
        }

        public async Task<List<HotelCategory>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HotelCategory> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Response> Update(UpdateDescDirectoryRequest request)
        {
            HotelCategory category = await _repository.GetByIdAsync(request.Id);
            category.Name = request.Name;
            category.Description = request.Description;
            _repository.UpdateAsync(category);

            return new Response(200, true, null);
        }

        public async Task<Response> Create(CreateDescDirectoryRequest request)
        {
            HotelCategory category = new HotelCategory()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now
            };

            _repository.AddAsync(category);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}