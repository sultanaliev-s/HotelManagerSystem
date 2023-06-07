using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        private readonly IRepository<City, int> _repository;
        private readonly CityServices _service;

        public CitiesController(IRepository<City, int> cityRepository, CityServices service)
        {
            _repository = cityRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<CityResponse> Create([FromBody] CreateIdNameDirectoryRequest request)
        {
            City city = new City()
            {
                Name = request.Name,
                CountryId = request.ParentId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            city = await _repository.AddAsync(city);

            return new CityResponse(200, true, null, city);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateIdNameDirectoryRequest request)
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
        public async Task<CityResponse> GetById(int id)
        {
            City city = await _service.GetByIdAsync(id);

            return new CityResponse(200, true, null, city);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<CityListResponse> GetAll(int id)
        {
            var list = await _repository.GetAllAsync();

            return new CityListResponse(200, true, null, list);
        }
    }
}
