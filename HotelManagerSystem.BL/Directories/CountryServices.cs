using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;

namespace HotelManagerSystem.BL.Directories
{
    public class CountryServices
    {
        private readonly IRepository<Country, int> _repository;

        public CountryServices( IRepository<Country, int> couontryRepository)
        {
            _repository = couontryRepository;
        }

        public async Task<List<Country>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Response> Update(UpdateNameDirectoryRequest request)
        {
            Country country = await _repository.GetByIdAsync(request.Id);
            country.Name = request.Name;
            _repository.UpdateAsync(country);

            return new Response(200, true, null );
        }

        public async Task<Response> Create(CreateNameDirectoryRequest request)
        {
            Country country =new Country()
            {
                Name = request.Name,
                CreatedDate = DateTime.Now

            };

            _repository.AddAsync(country);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}