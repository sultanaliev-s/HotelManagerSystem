using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
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

        public СouchettesController(IRepository<Сouchette, int> couchetteRepository, СouchetteServices service)
        {
            _repository = couchetteRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateNameDirectoryRequest request )
        {
            Сouchette couchette = new Сouchette()
            {
                Name = request.Name,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
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
        public async Task<СouchetteResponse> GetById(int id)
        {
            Сouchette couchette = await _service.GetByIdAsync(id);

            return new СouchetteResponse(200, true, null, couchette);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<СouchetteListResponse> GetAll(int id)
        {
            var list = await _repository.GetAllAsync();

            return new СouchetteListResponse(200, true, null, list);
        }
    }
}
