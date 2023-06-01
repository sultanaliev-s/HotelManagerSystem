using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
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
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now
            };

            review = await _repository.AddAsync(review);

            return new Response(200, true, null);
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<Response> GetById(int id)
        {
            ClientReview review = await _service.GetByIdAsync(id);

            return new Response(200, true, null);
        }


        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<Response> GetAll(int id)
        {
            await _repository.GetAllAsync();
            return new Response(200, true, null);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }

        //[HttpPost]
        //[Route("addStars")]
        //[Authorize]
        //public async Task<int> HotelStars([FromBody]List<ClientReview> Reviews, int Id)
        //{
        //    int result = await _service.HotelStars(Reviews);

        //    return result;
        //}
    }
}
