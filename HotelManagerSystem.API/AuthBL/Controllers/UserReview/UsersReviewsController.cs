using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.UserReview
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


    }
}
