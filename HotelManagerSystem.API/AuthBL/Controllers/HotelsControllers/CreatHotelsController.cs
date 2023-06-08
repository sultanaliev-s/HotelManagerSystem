using HotelManagerSystem.BL.HotelBL;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL;
using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelManagerSystem.DAL.Responses;
using NuGet.Protocol.Core.Types;
using HotelManagerSystem.Models.Request;
using MediatR;
using System.Xml.Linq;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;
using System.Runtime.CompilerServices;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities.Relations;

namespace HotelManagerSystem.API.AuthBL.Controllers.HotelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatHotelsController : ControllerBase
    {
        private readonly IRepository<Hotel, int> _hotelReporitory;
        private readonly IRepository<HotelsServices, int> _hotelsServicesReporitory;
        private readonly IRepository<Room, int> _roomReporitory;
        private readonly IRepository<Address, int> _addressReporitory;
        private readonly IRepository<HotelFoto, int> _fotoReporitory;
        private readonly UserReviewsServices _reviewsServices;
        private readonly HotelContext _context;
        private readonly CreateHotelDetailsServices _services;

        public CreatHotelsController(IRepository<Hotel, int> hotelReporitory,
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

        [HttpPost]
        [Route("createHotel")]
        public async Task<Response> CreateHotel([FromBody] string userId, string name, string description,
            bool isOne, string checkingAccount, int hotelTypeId, int hotelCategoryId, DateTime createDate)
        {
            Hotel hotel = new Hotel()
            {
                UserId = userId,
                Name = name,
                Description = description,
                IsOne = isOne,
                CheckingAccount = checkingAccount,
                HotelTypeId = hotelTypeId,
                HotelCategoryId = hotelCategoryId,
                CreatedDate = createDate
            };
            await _hotelReporitory.AddAsync(hotel);


            return new Response(200, true, null);
        }

        [HttpPost]
        [Route("createHotelDetails")]
        public async Task<Response> CreateHotelDetails([FromBody] int hotelId, int countryId, int CityId,
            string street, string streetNumber, string name, int amount, bool smoke, decimal price, int person,
            int type, int couchette, string fotos)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == hotelId);

            if (hotel == null || hotel.Id == 0)
            {
                throw new ArgumentNullException(nameof(hotelId), "Request cannot be null");

            }

            hotel.ClientReviews = await _reviewsServices.GetAll();

            CreateAddressRequest address = new(hotelId, countryId, CityId, street, streetNumber);
            CreateRoomRequest room = new(hotelId, name, amount, smoke, price, person, type, couchette);
            CreateFotoRequest foto = new(hotelId, fotos);
            ReviewRequest review = new(hotelId, hotel.ClientReviews);


            hotel.Addresses = await _services.AddAddress(address);
            hotel.Rooms = await _services.AddRoom(room);
            hotel.Fotos = await _services.AddFoto(foto);
            hotel.ReviewStars = await _reviewsServices.HotelStars(review);

            return new Response(200, true, null);
        }


        [HttpPost]
        [Route("createAddress")]
        public async Task<Response> CreateAddress([FromBody] int hotelId, int countryId, int cityId,
            string street, string streetNumber)
        {
            Address address = new Address()
            {
                CountryId = countryId,
                CityId = cityId,
                Street = street,
                StreetNumber = streetNumber
            };

            await _addressReporitory.AddAsync(address);

            return new Response(200, true, null); ;
        }

        [HttpPost]
        [Route("createFoto")]
        public async Task<Response> CreateFoto([FromBody] int hotelId, string fotos)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == hotelId);

            HotelFoto foto = new HotelFoto()
            {
                Foto = fotos,
                CreatedDate = DateTime.UtcNow
            };

            await _fotoReporitory.AddAsync(foto);

            return new Response(200, true, null);
        }

        [HttpPost]
        [Route("createRoom")]
        public async Task<Response> CreateRoom([FromBody] int hotelId, string name, int amount, bool smoke,
            decimal price, int person, int type, int couchette)
        {
            Room room = new Room()
            {
                Name = name,
                RoomAmount = amount,
                Smoke = smoke,
                Price = price,
                BasePerson = person,
                RoomTypeId = type,
                CouchetteId = couchette,
                CreatedDate = DateTime.UtcNow
            };

            await _roomReporitory.AddAsync(room);

            return new Response(200, true, null);
        }

    }
}
