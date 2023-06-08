using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Responses;
using Microsoft.AspNetCore.Authorization;
using HotelManagerSystem.Models.Request.UpdateRequest;
using HotelManagerSystem.Models.Request.CreateRequest;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize (Roles = "Admin")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly RoomTypeServices _service;

        public RoomTypesController(ILogger<CitiesController> logger,RoomTypeServices service)
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
                _logger.LogError(ex, "Error while processing request from { Room Type}", request);
            }

            return new Response(200,true, null);
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
                _logger.LogError(ex, "Error while processing request from {Room Type}", request);
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
        public async Task<RoomTypeResponse> GetById(int id)
        {
            RoomType roomType = await _service.GetByIdAsync(id);

            return new RoomTypeResponse(200, true, null, roomType); 
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<RoomTypesListresponse> GetAll()
        {
            var list = await _service.GetAll();

            return new RoomTypesListresponse(200, true, null, list); 
        }
    }
}
