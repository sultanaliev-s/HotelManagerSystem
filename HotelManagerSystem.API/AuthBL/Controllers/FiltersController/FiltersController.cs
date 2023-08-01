using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.BL.Filter;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.Search;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.FiltersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly ILogger<FiltersController> _logger;
        private readonly RoomReservationFilter _service;

        public FiltersController(ILogger<FiltersController> logger, RoomReservationFilter roomReservationFilter)
        {
            _logger = logger;
            _service = roomReservationFilter;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> HotelFilter([FromQuery] FilterRequest? request)
        {
            List<Hotel> result = new();
            try
            {
                result = await _service.Filter(request);
            }
            catch (BadRequestException ex)
            {
                BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Filter}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok(result);
        }
    }
}
