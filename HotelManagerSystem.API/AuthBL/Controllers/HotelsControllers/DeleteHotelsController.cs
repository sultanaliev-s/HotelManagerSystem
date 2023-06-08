using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HotelManagerSystem.API.AuthBL.Controllers.HotelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteHotelsController : ControllerBase
    {
        private readonly DaleteHotelDetailsServices _services;

        public DeleteHotelsController(DaleteHotelDetailsServices services)
        {
            _services = services;
        }


        [HttpDelete]
        [Route("deleteHotelById")]
        [Authorize(Roles = "Admin")]
        public async Task<Response> DeleteHotel(int id)
        {
            await _services.DeleteHotel(id);

            return new Response(200, true, null);
        }


        [HttpDelete]
        [Route("deleteRoomById")]
        [Authorize(Roles = "Owner")]
        public async Task<Response> DeleteRoom(int id)
        {
            await _services.DeleteRoom(id);

            return new Response(200, true, null);
        }

        [HttpDelete]
        [Route("deleteAddressById")]
        [Authorize(Roles = "Owner")]
        public async Task<Response> DeleteAddress(int id)
        {
            await _services.DeleteAddress(id);

            return new Response(200, true, null);
        }
    }
}
