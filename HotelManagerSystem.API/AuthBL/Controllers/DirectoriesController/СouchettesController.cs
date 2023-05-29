using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class СouchettesController : ControllerBase
    {

        private readonly IRepository<Сouchette, int> _repository;
        private readonly СouchetteServices _service;

        public СouchettesController(IRepository<Сouchette, int> couchetteRepository)
        {
            _repository = couchetteRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] string typeName )
        {
            Сouchette couchette = new Сouchette()
            {
                Name = typeName,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now
            };

            couchette = await _repository.AddAsync(couchette);

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
            Сouchette couchette = await _service.GetByIdAsync(id);

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
