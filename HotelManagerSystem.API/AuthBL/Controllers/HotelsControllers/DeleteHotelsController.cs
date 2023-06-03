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
        private readonly IRepository<Hotel, int> _hotelReporitory;
        private readonly IRepository<Room, int> _roomReporitory;
        private readonly IRepository<Address, int> _addressReporitory;
        private readonly IRepository<HotelFoto, int> _fotoReporitory;
        private readonly UserReviewsServices _reviewsServices;
        private readonly HotelContext _context;
        private readonly CreateHotelDetailsServices _services;

        public DeleteHotelsController(IRepository<Hotel, int> hotelReporitory,
            IRepository<Room, int> roomReporitory, IRepository<Address, int> addressReporitory,
            IRepository<HotelFoto, int> fotoReporitory, UserReviewsServices reviewsServices,
            CreateHotelDetailsServices services)
        {
            _hotelReporitory = hotelReporitory;
            _roomReporitory = roomReporitory;
            _addressReporitory = addressReporitory;
            _fotoReporitory = fotoReporitory;
            _reviewsServices = reviewsServices;
            _services = services;
        }


        [HttpDelete]
        [Route("deleteHotelById")]
        [Authorize(Roles = "Admin")]
        public async Task<Response> DeleteHotel(int id)
        {
            _hotelReporitory.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }


        [HttpDelete]
        [Route("deleteRoomById")]
        [Authorize(Roles = "Owner")]
        public async Task<Response> DeleteRoom(int id)
        {
            _roomReporitory.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }

        [HttpDelete]
        [Route("deleteAddressById")]
        [Authorize(Roles = "Owner")]
        public async Task<Response> DeleteAddress(int id)
        {
            _addressReporitory.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }

        [HttpDelete]
        [Route("deleteFotoById")]
        [Authorize(Roles = "Owner")]
        public async Task<Response> DeleteFoto(int id)
        {
            _fotoReporitory.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }

    }
}
