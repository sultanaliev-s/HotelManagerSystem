using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using HotelManagerSystem.BL.Exceptions;

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
        public async Task Update(UpdateNameDirectoryRequest request)
        {
            Country country = await _repository.GetByIdAsync(request.Id);
            if (country == null)
                throw new EntityNotFoundException<Country>();
            country.Name = request.Name;
            await _repository.UpdateAsync(country);
        }

        public async Task<int> Create(CreateNameDirectoryRequest request)
        {
            Country country =new Country()
            {
                Name = request.Name,
                CreatedDate = DateTime.UtcNow

            };

            var createdCountry = await _repository.AddAsync(country);

            return createdCountry.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}