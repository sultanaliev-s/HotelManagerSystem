using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<Response> Create([FromBody] int stars, string comment)
        {
            ClientReview review = new ClientReview()
            {
                Stars = stars,
                Comment = comment,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            review = await _repository.AddAsync(review);

            return new Response(200, true, null);
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<UserReviewsResponse> GetById(int id)
        {
            ClientReview review = await _service.GetByIdAsync(id);

            return new UserReviewsResponse(200, true, null, review);
        }


        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<UserReviewsListResponse> GetAll()
        {
            var list = await _repository.GetAllAsync();

            return new UserReviewsListResponse(200, true, null , list);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }

        [HttpPost]
        [Route("addStars")]
        [Authorize]
        public async Task<int> HotelStars([FromBody] ReviewRequest request)
        {
            int result = await _service.HotelStars(request);

            return result;
        }
    }
}
