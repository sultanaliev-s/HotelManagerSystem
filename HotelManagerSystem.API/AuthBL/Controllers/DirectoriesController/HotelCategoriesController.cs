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
    [ApiController]
    public class HotelCategoriesController : ControllerBase
    {

        private readonly IRepository<HotelCategory, int> _repository;
        private readonly HotelCategoryServices _service;

        public HotelCategoriesController(IRepository<HotelCategory, int> hotelCategoryRepository)
        {
            _repository = hotelCategoryRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] string typeName, string typeDescription)
        {
            HotelCategory category = new HotelCategory()
            {
                Name = typeName,
                Description = typeDescription,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now
            };

            category = await _repository.AddAsync(category);

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateDescDirectoryRequest request)
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
            HotelCategory category = await _service.GetByIdAsync(id);

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
