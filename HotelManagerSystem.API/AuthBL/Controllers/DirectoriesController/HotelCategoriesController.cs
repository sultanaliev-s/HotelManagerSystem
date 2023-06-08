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
    public class HotelCategoriesController : ControllerBase
    {

        private readonly IRepository<HotelCategory, int> _repository;
        private readonly HotelCategoryServices _service;

        public HotelCategoriesController(IRepository<HotelCategory, int> hotelCategoryRepository, HotelCategoryServices service)
        {
            _repository = hotelCategoryRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateIdDescDirectoryRequest request)
        {
            HotelCategory category = new HotelCategory()
            {
                Name = request.Name,
                Description = request.Description,
                HotelTypeId = request.ParentId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            category = await _repository.AddAsync(category);

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateIdDescDirectoryRequest request)
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
        public async Task<HotelCategoryResponse> GetById(int id)
        {
            HotelCategory category = await _service.GetByIdAsync(id);

            return new HotelCategoryResponse(200, true, null , category);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<HotelsCategoryListResponse> GetAll(int id)
        {
            var list = await _repository.GetAllAsync();

            return new HotelsCategoryListResponse(200, true, null, list);
        }
    }
}
