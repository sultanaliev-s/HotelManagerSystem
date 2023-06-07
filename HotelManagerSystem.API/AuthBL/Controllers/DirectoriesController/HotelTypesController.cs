using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.UpdateRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class HotelTypesController : ControllerBase
    {
        private readonly IRepository<HotelType, int> _repository;
        private readonly HotelTypeServices _service;

        public HotelTypesController(IRepository<HotelType, int> hotelTypeRepository, HotelTypeServices service)
        {
            _repository = hotelTypeRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] string typeName)
        {
            HotelType hotelType = new HotelType()
            {
                Name = typeName,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            hotelType = await _repository.AddAsync(hotelType);

            return new Response(200, true, null);
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
            HotelType hotelType = await _service.GetByIdAsync(id);

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
