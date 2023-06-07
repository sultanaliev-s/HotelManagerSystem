using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;

namespace HotelManagerSystem.BL.Directories
{
    public class CityServices
    {
        private readonly IRepository<City, int> _repository;

        public CityServices(IRepository<City, int> cityRepository)
        {
            _repository = cityRepository;
        }

        public async Task<List<City>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Response> Update(UpdateIdNameDirectoryRequest request)
        {
            City city = await _repository.GetByIdAsync(request.Id);
            city.Name = request.Name;
            city.CountryId = request.ParentId;
            _repository.UpdateAsync(city);

            return new Response(200, true, null);
        }

        public async Task<Response> Create(CreateIdNameDirectoryRequest request)
        {
            City city = new City()
            {
                Name = request.Name,
                CountryId = request.ParentId,
                CreatedDate = DateTime.Now, 
                UpdatedDate = DateTime.Now
                
            };

            _repository.AddAsync(city);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}