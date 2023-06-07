using HotelManagerSystem.BL.Filter;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Request.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.FiltersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly RoomReservationFilter _service;

        public FiltersController(RoomReservationFilter roomReservationFilter)
        {
            _service = roomReservationFilter;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<HotelsListResponse> HotelFilter([FromQuery] FilterRequest? requst)
        {
            var result = await _service.Filter(requst);

            return new HotelsListResponse(200, null, true, result);
        }
    }
}
