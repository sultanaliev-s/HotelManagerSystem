using HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController;
using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;
using System.Runtime.CompilerServices;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities.Relations;
using HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController;
using HotelManagerSystem.API.Responses;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.API.AuthBL.Controllers.HotelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatHotelsController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly HotelContext _context;
        private readonly CreateHotelDetailsServices _services;

        public CreatHotelsController(HotelContext context, CreateHotelDetailsServices services,
            ILogger<CitiesController> logger)
        {
            _context = context;
            _services = services;
            _logger = logger;
        }

        [HttpPost]
        [Route("createHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelRequest request)
        {
            try
            {
                var hotel = await _services.CreateHotel(request);
                return Created("", hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Create Hotel}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        [Route("createAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressRequest request)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == request.Hotel);

            if (hotel == null || hotel.Id == 0)
            {
                return BadRequest(new ErrorResponse("Hotel not Found"));
            }
            else
            {
                try
                {
                    var address = await _services.AddAddress(request);
                    return Created("", address);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while processing request from {CreateAdress}", request);
                    return BadRequest(new ErrorResponse(ex.Message));
                }
            }
        }

        [HttpPost]
        [Route("createRoom")]
        public async Task<IActionResult> CreateRoom([FromForm] CreateRoomRequest request)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == request.HotelId);

            if (hotel == null || hotel.Id == 0)
            {
                return BadRequest(new ErrorResponse("Hotel not Found"));
            }
            else
            {
                try
                {
                    var room = await _services.AddRoom(request);
                    return Created("", room);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while processing request from {CreateAdress}", request);
                    return BadRequest(new ErrorResponse(ex.Message));
                }
            }
        }

        [HttpGet]
        [Route("listHotel")]
        public async Task<ActionResult<List<ListHotelsDto>>> ListHotels()
        {
            try
            {
                return Ok(await _services.GettAllHotels());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {List Hotel}");
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet]
        [Route("hotelById/{id}")]
        public async Task<ActionResult<HotelDetailsDto>> ListHotels([FromRoute]int id)
        {
            try
            {
                return Ok(await _services.GetHotelById(id));
            }
            catch (EntityNotFoundException<Hotel> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {List Hotel}");
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

    }
}
