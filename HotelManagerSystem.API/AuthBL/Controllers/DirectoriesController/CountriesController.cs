using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.UpdateRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly IRepository<Country, int> _repository;
        private readonly CountryServices _service;

        public CountriesController(IRepository<Country, int> countryRepository, CountryServices service)
        {
            _repository = countryRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] string CountryName)
        {
            Country country = new Country()
            {
                Name = CountryName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            country = await _repository.AddAsync(country);

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
            Country country = await _service.GetByIdAsync(id);

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
