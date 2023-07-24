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
using System.Diagnostics.Metrics;
using System.Linq;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class HotelCategoriesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly HotelCategoryServices _service;

        public HotelCategoriesController(ILogger<CitiesController> logger, HotelCategoryServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] CreateIdDescDirectoryRequest request)
        {
            try
            {
                var country = await _service.Create(request);
                return Created("", country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Category}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(UpdateIdDescDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (EntityNotFoundException<HotelCategory> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel Category}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            HotelCategory hotelCategory = await _service.GetByIdAsync(id);
            if (hotelCategory == null)
                return NotFound(new ErrorResponse("Hotel Category not found"));
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<ActionResult> GetById(int id)
        {
            HotelCategory hotelCategory = await _service.GetByIdAsync(id);
            if (hotelCategory == null)
                return NotFound(new ErrorResponse("Hotel Category not found"));
            return Ok(new HotelCategoryDto(hotelCategory));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<ActionResult<List<HotelCategoryDto>>> GetAll()
        {
            var list = await _service.GetAll();

            return Ok(list.Select(dep => new HotelCategoryDto(dep)).ToList());
        }
    }
}
