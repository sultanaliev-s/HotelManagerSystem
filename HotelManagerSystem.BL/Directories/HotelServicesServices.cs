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
        public async Task<Response> Update(UpdateDescDirectoryRequest request)
        {
            HotelServices services = await _repository.GetByIdAsync(request.Id);
            services.Name = request.Name;
            services.Description = request.Description;
            _repository.UpdateAsync(services);

            return new Response(200, true, null);
        }

        public async Task<Response> Create(CreateDescDirectoryRequest request)
        {
            HotelServices services = new HotelServices()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now

            };

            _repository.AddAsync(services);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}