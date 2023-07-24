using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using HotelManagerSystem.Models.Request.UserReview;

namespace HotelManagerSystem.BL.Directories
{
    public class HotelServicesServices
    {
        private readonly IRepository<HotelServices, int> _repository;

        public HotelServicesServices(IRepository<HotelServices, int> hotelServicesRepository)
        {
            _repository = hotelServicesRepository;
        }

        public async Task<List<HotelServices>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HotelServices> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task Update(UpdateDescDirectoryRequest request)
        {
            HotelServices services = await _repository.GetByIdAsync(request.Id);
            if (services == null)
                throw new EntityNotFoundException<HotelServices>();
            services.Name = request.Name;
            services.Description = request.Description;
            await _repository.UpdateAsync(services);
        }

        public async Task<int> Create(CreateDescDirectoryRequest request)
        {
            HotelServices services = new HotelServices()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow

            };

            var createdService = await _repository.AddAsync(services);

            return createdService.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}