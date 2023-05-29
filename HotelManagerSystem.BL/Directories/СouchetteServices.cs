using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;

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
        public async Task<Response> Update(UpdateNameDirectoryRequest request)
        {
            Сouchette couchette = await _repository.GetByIdAsync(request.Id);
            couchette.Name = request.Name;
            _repository.UpdateAsync(couchette);

            return new Response(200, true, null);
        }

        public async Task<Response> Create(CreateNameDirectoryRequest request)
        {   
            Сouchette сouchette = new Сouchette()
            {
                Name = request.Name,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now

            };

            _repository.AddAsync(сouchette);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}