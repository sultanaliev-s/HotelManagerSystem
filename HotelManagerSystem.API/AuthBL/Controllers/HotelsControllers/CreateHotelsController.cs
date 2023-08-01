using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.DAL.Responses;
using NuGet.Protocol.Core.Types;
using HotelManagerSystem.Models.Request;
using MediatR;
using System.Xml.Linq;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;
using System.Runtime.CompilerServices;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities.Relations;
using HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController;
using HotelManagerSystem.API.Responses;

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
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest request)
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

    }
}
