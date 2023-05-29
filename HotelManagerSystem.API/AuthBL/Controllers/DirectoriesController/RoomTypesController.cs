using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.DAL.Responses;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize (Roles = "Admin")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRepository<RoomType, int> _repository;
        private readonly RoomTypeServices _service;

        public RoomTypesController(IRepository<RoomType, int> roomTypeRepository)
        {
            _repository = roomTypeRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] string typeName)
        {
            RoomType roomType = new RoomType()
            {
                Name = typeName,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now
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
        public async Task<Response> GetById(int id)
        {
            RoomType roomType = await _service.GetByIdAsync(id);

            return new Response(200, true, null); 
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<Response> GetAll(int id)
        {
            await _repository.GetAllAsync();
            return new Response(200, true, null); 
        }
    }
}
