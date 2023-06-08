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

        private readonly ILogger<CitiesController> _logger;
        private readonly СouchetteServices _service;

        public СouchettesController( СouchetteServices service, ILogger<CitiesController> logger)
        {
            _service = service;
            _logger = logger;
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
                _logger.LogError(ex, "Error while processing request from {Сouchette}", request);
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
                _logger.LogError(ex, "Error while processing request from {Сouchette}", request);
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
        public async Task<СouchetteResponse> GetById(int id)
        {
            Сouchette couchette = await _service.GetByIdAsync(id);

            return new СouchetteResponse(200, true, null, couchette);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<СouchetteListResponse> GetAll()
        {
            var list = await _service.GetAll();

            return new СouchetteListResponse(200, true, null, list);
        }
    }
}
