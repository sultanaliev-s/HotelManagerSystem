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

        private readonly ILogger<CitiesController> _logger;
        private readonly HotelServicesServices _service;

        public HotelServicesController(ILogger<CitiesController> logger, HotelServicesServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateDescDirectoryRequest request)
        {
            try
            {
                await _service.Create(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Services}", request);
            }

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateDescDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Services}", request);
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
        public async Task<HotelServicesResponse> GetById(int id)
        {
            HotelServices services = await _service.GetByIdAsync(id);

            return new HotelServicesResponse(200, true, null, services);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<HotelServicesListResponse> GetAll()
        {
            var list = await _service.GetAll();

            return new HotelServicesListResponse(200, true, null, list);
        }
    }
}
