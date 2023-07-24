using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.Metrics;

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
        public async Task<ActionResult> Create([FromBody] CreateIdNameDirectoryRequest request)
        {
            try
            {

                var city = await _service.Create(request);
                return Created("", city);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {City}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(UpdateIdNameDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (EntityNotFoundException<City> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {City}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            City city = await _service.GetByIdAsync(id);
            if (city == null)
                return NotFound(new ErrorResponse("City not found"));
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            City city = await _service.GetByIdAsync(id);

            if (city == null)
                return NotFound(new ErrorResponse("Country not found"));
            return Ok(new CityDto(city));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<ActionResult<List<CityDto>>> GetAll()
        {
            var list = await _service.GetAll();

            return Ok(list.Select(dep => new CityDto(dep)).ToList());
        }
    }
}
