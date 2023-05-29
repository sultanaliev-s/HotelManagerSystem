using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;

namespace HotelManagerSystem.BL.Directories
{
    public class HotelTypeServices
    {
        private readonly IRepository<HotelType, int> _repository;

        public HotelTypeServices(IRepository<HotelType, int> hotelTypeRepository)
        {
            _repository = hotelTypeRepository;
        }

        public async Task<List<HotelType>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HotelType> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Response> Update(UpdateNameDirectoryRequest request)
        {
            HotelType hotelType = await _repository.GetByIdAsync(request.Id);
            hotelType.Name = request.Name;
            _repository.UpdateAsync(hotelType);

            return new Response(200, true, null);
        }

        public async Task<Response> Create(CreateNameDirectoryRequest request)
        {
            HotelType hotelType = new HotelType()
            {
                Name = request.Name,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now

            };

            _repository.AddAsync(hotelType);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}