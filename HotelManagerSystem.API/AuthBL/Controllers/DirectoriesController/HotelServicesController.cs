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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Linq;

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
        public async Task<ActionResult> Create([FromBody] CreateDescDirectoryRequest request)
        {
            try
            {
                var service = await _service.Create(request);
                return Created("", service);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Services}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(UpdateDescDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (EntityNotFoundException<HotelServices> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Services}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            HotelServices hotelServices = await _service.GetByIdAsync(id);
            if (hotelServices == null)
                return NotFound(new ErrorResponse("Hotel Services not found"));
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<ActionResult<HotelServicesDto>> GetById(int id)
        {
            HotelServices hotelServices = await _service.GetByIdAsync(id);
            if (hotelServices == null)
                return NotFound(new ErrorResponse("Hotel Services not found"));

            return Ok(new HotelServicesDto(hotelServices));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<ActionResult<List<HotelServicesDto>>> GetAll()
        {
            var list = await _service.GetAll();

            return Ok(list.Select(dep => new HotelServicesDto(dep)).ToList());
        }
    }
}
