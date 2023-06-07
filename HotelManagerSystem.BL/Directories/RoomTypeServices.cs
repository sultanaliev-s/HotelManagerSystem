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
        public async Task<Response> Update(UpdateNameDirectoryRequest request)
        {
            RoomType roomType = await _repository.GetByIdAsync(request.Id);
            roomType.Name = request.Name;
            _repository.UpdateAsync(roomType);

            return new Response(200, true, null);
        }

        public async Task<Response> Create(CreateNameDirectoryRequest request)
        {
            RoomType roomType = new RoomType()
            {
                Name = request.Name,
                CreatedDate = DateTime.Now, 
                UpdatedDate = DateTime.Now

            };

            _repository.AddAsync(roomType);

            return new Response(200, true, null);
        }

        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}
