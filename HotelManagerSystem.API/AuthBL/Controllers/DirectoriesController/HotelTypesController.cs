using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
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
        private readonly ILogger<CitiesController> _logger;
        private readonly HotelTypeServices _service;

        public HotelTypesController(ILogger<CitiesController> logger, HotelTypeServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateNameDirectoryRequest request)
        {
            try
            {
                await _service.Create(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Types}", request);
            }

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateNameDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Types}", request);
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
        public async Task<HotelTypeResponse> GetById(int id)
        {
            HotelType hotelType = await _service.GetByIdAsync(id);

            return new HotelTypeResponse(200, true, null, hotelType);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<HotelTypesListResponse> GetAll()
        {
            var list = await _service.GetAll();

            return new HotelTypesListResponse(200, true, null, list);
        }
    }
}
