using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.Models.DTOs;
using NuGet.Protocol;
using System.Diagnostics.Metrics;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly CountryServices _service;

        public CountriesController(ILogger<CitiesController> logger, CountryServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] CreateNameDirectoryRequest request)
        {
            try
            {
                var country = await _service.Create(request);
                return Created("", country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Country}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(UpdateNameDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (EntityNotFoundException<Country> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Country}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            Country country = await _service.GetByIdAsync(id);
            if (country == null)
                return NotFound(new ErrorResponse("Country not found"));
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<ActionResult<CountryResponse>> GetById(int id)
        {
            Country country = await _service.GetByIdAsync(id);
            if(country == null)
                return NotFound(new ErrorResponse("Country not found"));
            return Ok(new CountryDto(country));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<ActionResult<List<CountryDto>>> GetAll()
        {
            var list = await _service.GetAll();

            return Ok(list.Select(dep => new CountryDto(dep)).ToList());
        }
    }
}
