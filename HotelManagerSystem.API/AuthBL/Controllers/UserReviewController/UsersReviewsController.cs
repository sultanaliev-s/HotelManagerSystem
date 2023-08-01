using System.Security.Claims;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.UserReview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.UserReviewController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    [ApiController]
    public class UsersReviewsController : ControllerBase
    {
        private readonly IRepository<ClientReview, int> _repository;
        private readonly UserReviewsServices _service;

        public UsersReviewsController(IRepository<ClientReview, int> repository, UserReviewsServices reviewsServices)
        {
            _repository = repository;
            _service = reviewsServices;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserReviewRequest req)
        {
            try
            {
                var review = await _service.Create(req, User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Created("", review);
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

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var review = await _service.GetByIdAsync(id);
                return Ok(review);
            }
            catch (EntityNotFoundException<ClientReview> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }


        [HttpGet]
        [Route("GetAllForHotel")]
        [Authorize]
        public async Task<IActionResult> GetAllForHotel([FromQuery] int hotelId)
        {
            var list = await _service.GetAllForHotel(hotelId);

            return Ok(list);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.GetByIdAsync(id);
                await _service.Delete(id);
                return NoContent();
            }
            catch (EntityNotFoundException<ClientReview> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        [Route("HotelStars")]
        [Authorize]
        public async Task<int> HotelStars([FromQuery] int hotelId)
        {
            int result = await _service.HotelStars(hotelId);

            return result;
        }
    }
}
