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

        private readonly ILogger<CitiesController> _logger;
        private readonly HotelCategoryServices _service;

        public HotelCategoriesController(ILogger<CitiesController> logger, HotelCategoryServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateIdDescDirectoryRequest request)
        {
            try
            {
                await _service.Create(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Category}", request);
            }

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateIdDescDirectoryRequest request)
        {
            try
            {
              await _service.Update(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Category}", request);
            }

            return new Response(200, true, null);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Response> Delete(int id)
        {
           await _service.Delete(id);

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
        public async Task<HotelsCategoryListResponse> GetAll()
        {
            var list = await _service.GetAll();

            return new HotelsCategoryListResponse(200, true, null, list);
        }
    }
}
