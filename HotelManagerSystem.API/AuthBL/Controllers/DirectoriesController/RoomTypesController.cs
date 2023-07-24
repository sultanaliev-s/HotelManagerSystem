using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Responses;
using Microsoft.AspNetCore.Authorization;
using HotelManagerSystem.Models.Request.UpdateRequest;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;
using System.Diagnostics.Metrics;
using System.Linq;

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
        public async Task<ActionResult> Create([FromBody] CreateNameDirectoryRequest request)
        {
            try
            {
                var type = await _service.Create(request);
                return Created("", type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Room Type}", request);
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
            catch (EntityNotFoundException<RoomType> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Room Type}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            RoomType roomType = await _service.GetByIdAsync(id);
            if (roomType == null)
                return NotFound(new ErrorResponse("Room Type not found"));
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<ActionResult<RoomTypeDto>> GetById(int id)
        {
            RoomType roomType = await _service.GetByIdAsync(id);
            if (roomType == null)
                return NotFound(new ErrorResponse("Room Type not found"));
            return Ok(new RoomTypeDto(roomType));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<ActionResult<List<RoomTypeDto>>> GetAll()
        {
            var list = await _service.GetAll();

            return Ok(list.Select(dep => new RoomTypeDto(dep)).ToList());
        }
    }
}
