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
using HotelManagerSystem.Models.Request.CreateRequest;

namespace HotelManagerSystem.API.AuthBL.Controllers.HotelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsPhotosController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly HotelContext _context;
        private readonly CreateHotelDetailsServices _services;

        public HotelsPhotosController(HotelContext context, CreateHotelDetailsServices services,
            ILogger<CitiesController> logger)
        {
            _context = context;
            _services = services;
            _logger = logger;
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddHotelPhotoRequest([FromForm] AddHotelPhotoRequest request)
        {
            try
            {
                await _services.AddPhotos(request);
                return Created("", "");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Add photo to hotel}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePhotoById([FromRoute]int id)
        {
            try
            {
                await _services.DeletePhoto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Delete photo}");
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
    }

}