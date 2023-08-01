using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Exceptions;
using MediatR;
using HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController;

namespace HotelManagerSystem.API.AuthBL.Controllers.HotelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteHotelsController : ControllerBase
    {
        private readonly DaleteHotelDetailsServices _services;
        private readonly ILogger<CitiesController> _logger;

        public DeleteHotelsController(DaleteHotelDetailsServices services, ILogger<CitiesController> logger)
        {
            _services = services;
            _logger = logger;
        }


        [HttpDelete]
        [Route("deleteHotelById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHotel([FromQuery] int id)
        {
            
            try
            {
                await _services.DeleteHotel(id);
            }
            catch (EntityNotFoundException<Hotel> ex)
            {
                return NotFound(new ErrorResponse("Hotel not found"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Delete Hotel}", id);
                return BadRequest(new ErrorResponse(ex.Message));
            }
            return NoContent();
        }


        [HttpDelete]
        [Route("deleteRoomById")]
        public async Task<IActionResult> DeleteRoom([FromQuery] int id)
        {

            try
            {
                await _services.DeleteRoom(id);
            }
            catch (EntityNotFoundException<Room> ex)
            {
                return NotFound(new ErrorResponse("Room not found"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Delete Room}", id);
                return BadRequest(new ErrorResponse(ex.Message));
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("deleteAddressById")]
        public async Task<IActionResult> DeleteAddress([FromQuery]int id)
        {
            try
            {
                await _services.DeleteAddress(id);
            }
            catch(EntityNotFoundException<Address> ex)
            {
                return NotFound(new ErrorResponse("Address not found"));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Delete Address}", id);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return NoContent();
        }
    }
}
