using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly CityServices _service;

        public CitiesController(ILogger<CitiesController> logger, CityServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] CreateIdNameDirectoryRequest request)
        {
            try
            {

                await _service.Create(request);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {City}", request);
            }

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateIdNameDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {City}", request);
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
        public async Task<CityResponse> GetById(int id)
        {
            City city = await _service.GetByIdAsync(id);

            return new CityResponse(200, true, null, city);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<CityListResponse> GetAll()
        {
            var list = await _service.GetAll();

            return new CityListResponse(200, true, null, list);
        }
    }
}
