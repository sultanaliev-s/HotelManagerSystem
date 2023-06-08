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
        public async Task<Response> CreateHotel([FromBody] CreateHotelRequest request,[FromQuery] ReviewRequest request1)
        {
            try
            {
                await _services.CreateHotel(request, request1);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Hotel create}", request);

            }

            return new Response(200, true, null);
        }

        [HttpPost]
        [Route("createAddress")]
        public async Task<Response> CreateAddress([FromBody] CreateAddressRequest request)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == request.Hotel);

            if (hotel == null || hotel.Id == 0)
            {
                throw new ArgumentNullException(nameof(request.Hotel), "Request cannot be null");
            }
            else
            {
                try
                {
                    await _services.AddAddress(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while processing request from {Address create}", request);
                }
            }

            return new Response(200, true, null); ;
        }

        [HttpPost]
        [Route("createRoom")]
        public async Task<Response> CreateRoom([FromBody] CreateRoomRequest request)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == request.hotelId);

            if (hotel == null || hotel.Id == 0)
            {
                throw new ArgumentNullException(nameof(request.hotelId), "Request cannot be null");
            }
            else
            {
                try
                {
                    await _services.AddRoom(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while processing request from {Room create}", request);
                }
            }

            return new Response(200, true, null);
        }

    }
}
