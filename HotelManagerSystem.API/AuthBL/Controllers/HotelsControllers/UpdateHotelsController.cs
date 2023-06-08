using HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController;
using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.DTOs;
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
        public async Task<Response> Update(CreateHotelRequest request)
        {
            try
            {
                await _services.UpdateHotel(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Room Type}", request);
            }

            return new Response(200, true, null);
        }
        
        [HttpPut]
        [Route("updateHotelsServices")]
        public async Task<Response> UpdateHotelsServices(int id, HotelDto dto)
        {
            try
            {
                await _services.UpdateHotelServices(id, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Room Type}");
            }

            return new Response(200, true, null);
        }

    }
}
