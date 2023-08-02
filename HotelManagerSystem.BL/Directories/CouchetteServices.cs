using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;

namespace HotelManagerSystem.BL.Directories
{
    public class CouchetteServices
    {
        private readonly IRepository<Couchette, int> _repository;

        public CouchetteServices(IRepository<Couchette, int> couchetteRepository)
        {
            _repository = couchetteRepository;
        }

        public async Task<List<Couchette>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Couchette> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task Update(UpdateNameDirectoryRequest request)
        {
            Couchette couchette = await _repository.GetByIdAsync(request.Id);
            if (couchette == null)
                throw new EntityNotFoundException<Couchette>();
            couchette.Name = request.Name;
            await _repository.UpdateAsync(couchette);
        }

        public async Task<int> Create(CreateCouchetteRequest request)
        {
            Couchette сouchette = new Couchette()
            {
                Name = request.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                RoomId = request.RoomId,

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