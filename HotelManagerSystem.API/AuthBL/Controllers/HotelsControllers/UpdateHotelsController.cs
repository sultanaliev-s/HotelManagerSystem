using HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.HotelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateHotelsController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly UpdateHotelDetalisServices _services;

        public UpdateHotelsController(UpdateHotelDetalisServices services,
            ILogger<CitiesController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpPut]
        [Route("updateHotel")]
        public async Task<IActionResult> Update(UpdateHotelRequest request)
        {
            try
            {
                await _services.UpdateHotel(request);
            }
            catch (EntityNotFoundException<Hotel> ex)
            {
                return NotFound(new ErrorResponse("Hotel not found"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Update Hotel}");
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }
        
        [HttpPut]
        [Route("updateHotelsServices")]
        public async Task<IActionResult> UpdateHotelsServices(UpdateHotelServicesRequest request)
        {
            try
            {
                await _services.UpdateHotelServices(request);
            }
            catch (EntityNotFoundException<Hotel> ex)
            {
                return NotFound(new ErrorResponse("Hotel not found"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Update Hotels Service}");
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

    }
}
