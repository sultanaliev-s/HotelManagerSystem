using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public async Task<ActionResult> Create([FromBody] CreateNameDirectoryRequest request)
        {
            try
            {
                var hotelType = await _service.Create(request);
                return Created("", hotelType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Types}", request);
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
            catch (EntityNotFoundException<HotelType> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Types}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            HotelType hotelType = await _service.GetByIdAsync(id);
            if (hotelType == null)
                return NotFound(new ErrorResponse("Hotel Type not found"));
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<ActionResult> GetById(int id)
        {
            HotelType hotelType = await _service.GetByIdAsync(id);
            if (hotelType == null)
                return NotFound(new ErrorResponse("Hotel Type not found"));
            return Ok(new HotelTypeDto(hotelType));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<ActionResult<List<HotelTypeDto>>> GetAll()
        {
            var list = await _service.GetAll();

            return Ok(list.Select(dep => new HotelTypeDto(dep)).ToList());

        }
    }
}
