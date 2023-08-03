using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;

namespace HotelManagerSystem.BL.Directories
{
    public class СouchetteServices
    {
        private readonly IRepository<Сouchette, int> _repository;

        public СouchetteServices(IRepository<Сouchette, int> couchetteRepository)
        {
            _repository = couchetteRepository;
        }

        public async Task<List<Сouchette>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Сouchette> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task Update(UpdateNameDirectoryRequest request)
        {
            Сouchette couchette = await _repository.GetByIdAsync(request.Id);
            if (couchette == null)
                throw new EntityNotFoundException<Сouchette>();
            couchette.Name = request.Name;
            await _repository.UpdateAsync(couchette);
        }

        public async Task<int> Create(CreateCouchetteRequest request)
        {
            Сouchette сouchette = new Сouchette()
            {
                Name = request.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,

            };

            var createdCouchette = await _repository.AddAsync(сouchette);

            return createdCouchette.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}