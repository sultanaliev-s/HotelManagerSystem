using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using HotelManagerSystem.BL.Exceptions;

namespace HotelManagerSystem.BL.Directories
{
    public class RoomTypeServices
    {
        private readonly IRepository<RoomType, int> _repository;

        public RoomTypeServices(IRepository<RoomType, int> roomTypeRepository)
        {
            _repository = roomTypeRepository;
        }

        public async Task<List<RoomType>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task Update(UpdateNameDirectoryRequest request)
        {
            RoomType roomType = await _repository.GetByIdAsync(request.Id);
            if (roomType == null)
                throw new EntityNotFoundException<RoomType>();
            roomType.Name = request.Name;
            await _repository.UpdateAsync(roomType);
        }

        public async Task<int> Create(CreateNameDirectoryRequest request)
        {
            RoomType roomType = new RoomType()
            {
                Name = request.Name,
                CreatedDate = DateTime.UtcNow, 
                UpdatedDate = DateTime.UtcNow

            };

            var createdType = await _repository.AddAsync(roomType);

            return createdType.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
