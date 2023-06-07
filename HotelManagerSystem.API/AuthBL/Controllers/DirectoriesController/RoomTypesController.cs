using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Responses;
using Microsoft.AspNetCore.Authorization;
using HotelManagerSystem.Models.Request.UpdateRequest;
using HotelManagerSystem.Models.Request.CreateRequest;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize (Roles = "Admin")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRepository<RoomType, int> _repository;
        private readonly RoomTypeServices _service;

        public RoomTypesController(IRepository<RoomType, int> roomTypeRepository, RoomTypeServices service)
        {
            _repository = roomTypeRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateNameDirectoryRequest request)
        {
            RoomType roomType = new RoomType()
            {
                Name = request.Name,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            roomType = await _repository.AddAsync(roomType);

            return new Response(200,true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateNameDirectoryRequest request)
        {
            return await _service.Update(request);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<RoomTypeResponse> GetById(int id)
        {
            RoomType roomType = await _service.GetByIdAsync(id);

            return new RoomTypeResponse(200, true, null, roomType); 
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<RoomTypesListresponse> GetAll(int id)
        {
            var list = await _repository.GetAllAsync();

            return new RoomTypesListresponse(200, true, null, list); 
        }
    }
}
