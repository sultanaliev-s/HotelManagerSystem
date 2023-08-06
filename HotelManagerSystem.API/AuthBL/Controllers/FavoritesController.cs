using System.Security.Claims;
using HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.UserReview;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.API.AuthBL.Controllers.UserReviewController
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly HotelContext _context;
        private readonly CreateHotelDetailsServices _services;

        public FavoritesController(HotelContext context, CreateHotelDetailsServices services,
            ILogger<CitiesController> logger)
        {
            _context = context;
            _services = services;
            _logger = logger;
        }

        [HttpGet]
        [Route("myFavorites")]
        public async Task<ActionResult<List<FavoriteHotel>>> MyFavorites()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var favorites = _context.FavoritesHotels.Where(x => x.User.Id == userId).Include(x => x.Hotel);
                var result = favorites.Adapt<List<FavoriteHotel>>();
                return result;
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] int hotelId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var favorite = await _services.AddToFavorities(hotelId, userId);
                return Created("", favorite);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFavorities([FromRoute] int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _services.DeleteFavorities(id, userId);
                return NoContent();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
    }
}