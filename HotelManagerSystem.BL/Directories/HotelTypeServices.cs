using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;

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
        public async Task Update(UpdateNameDirectoryRequest request)
        {
            HotelType hotelType = await _repository.GetByIdAsync(request.Id);
            if (hotelType == null)
                throw new EntityNotFoundException<HotelType>();
            hotelType.Name = request.Name;
            await _repository.UpdateAsync(hotelType);
        }

        public async Task<int> Create(CreateNameDirectoryRequest request)
        {
            HotelType hotelType = new HotelType()
            {
                Name = request.Name,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow

            };

            var createdHotelType = await _repository.AddAsync(hotelType);

            return createdHotelType.Id;
        }

        public async Task<Response> Delete(int id)
        {
            await _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}