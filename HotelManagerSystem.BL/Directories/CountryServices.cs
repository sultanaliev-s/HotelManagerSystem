using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.API.Responses;

namespace HotelManagerSystem.BL.Directories
{
    public class CountryServices
    {
        private readonly IRepository<Country> _repository;

        public CountryServices( IRepository<Country> couontryRepository)
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
                CreatedUtc = DateTime.Now

            };

            _repository.AddAsync(country);

            return new Response(200, true, null);
        }

        //public async Task<Response> Delete(DeleteNameDirectoryRequest request)
        //{

        //    _repository.DeleteAsync(request);

        //    return new Response(200, true, null);
        //}





    }
}