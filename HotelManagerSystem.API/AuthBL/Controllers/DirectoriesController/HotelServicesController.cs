using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
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
    public class HotelServicesController : ControllerBase
    {

        private readonly IRepository<HotelServices, int> _repository;
        private readonly HotelServicesServices _service;

        public HotelServicesController(IRepository<HotelServices, int> hotelServicesRepository, HotelServicesServices service)
        {
            _repository = hotelServicesRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateDescDirectoryRequest request)
        {
            HotelServices services = new HotelServices()
            {
                Name = request.Name,
                Description = request.Description,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            services = await _repository.AddAsync(services);

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateDescDirectoryRequest request)
        {
            await _service.Update(request);

            return new Response(200, true, null);
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
        public async Task<HotelServicesResponse> GetById(int id)
        {
            HotelServices services = await _service.GetByIdAsync(id);

            return new HotelServicesResponse(200, true, null, services);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<HotelServicesListResponse> GetAll(int id)
        {
            var list = await _repository.GetAllAsync();

            return new HotelServicesListResponse(200, true, null, list);
        }
    }
}
