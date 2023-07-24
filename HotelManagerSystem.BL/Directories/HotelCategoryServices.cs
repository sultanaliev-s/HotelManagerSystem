using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;

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
        public async Task Update(UpdateIdDescDirectoryRequest request)
        {
            HotelCategory category = await _repository.GetByIdAsync(request.Id);
            category.Name = request.Name;
            category.Description = request.Description;
            category.HotelTypeId = request.ParentId;
            await _repository.UpdateAsync(category);
        }

        public async Task<int> Create(CreateIdDescDirectoryRequest request)
        {
            HotelCategory category = new HotelCategory()
            {
                Name = request.Name,
                Description = request.Description,
                HotelTypeId = request.HotelTypeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            var createdHotelCategory = await _repository.AddAsync(category);

            return createdHotelCategory.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}