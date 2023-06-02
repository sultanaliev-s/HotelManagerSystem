using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HotelManagerSystem.BL.HotelBL
{
    public class CreateHotelDetailsServices
    {
        private readonly IRepository<Hotel, int> _hotelReporitory;
        private readonly IRepository<Room, int> _roomReporitory;
        private readonly IRepository<Address, int> _addressReporitory;
        private readonly IRepository<HotelFoto, int> _fotoReporitory;
        private readonly UserReviewsServices _reviewsServices;
        private readonly HotelContext _context;

        public CreateHotelDetailsServices(IRepository<Hotel, int> hotelReporitory,
            IRepository<Room, int> roomReporitory, IRepository<Address, int> addressReporitory,
            IRepository<HotelFoto, int> fotoReporitory, UserReviewsServices reviewsServices, HotelContext context)
        {
            _hotelReporitory = hotelReporitory;
            _roomReporitory = roomReporitory;
            _addressReporitory = addressReporitory;
            _fotoReporitory = fotoReporitory;
            _reviewsServices = reviewsServices;
            _context = context;
        }
        public async Task<List<Hotel>> GetAll()
        {
            return await _hotelReporitory.GetAllAsync();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _hotelReporitory.GetByIdAsync(id);
        }

        // не знаю как дальше писать этот пиздец 

        public async Task<Response> CreateHotel(CreateHotelRequest request, CreateAddressRequest Addressrequest,
            CreateRoomRequest roomRequest, ReviewRequest reviewRequest, CreateFotoRequest fotoRequest)
        {
            Hotel hotel = new Hotel()
            {
                UserId= request.UserId,
                Name = request.Name,
                Description = request.Description,
                IsOne = request.IsOne,
                CheckingAccount = request.CheckingAccount,
                Addresses = await AddAddress(Addressrequest),
                Rooms = await AddRoom(roomRequest),
                Fotos = await AddFoto(fotoRequest),
                ReviewStars = await _reviewsServices.HotelStars(reviewRequest),
                ClientReviews = await _reviewsServices.GetAll(),
                HotelTypeId = request.HotelTypeId,
                HotelCategoryId = request.HotelCategoryId,
                CreatedUtc = request.CreateDate
            };
            await _hotelReporitory.AddAsync(hotel);

            return new Response(200, true, null);
        }

        public async Task<List<Address>> AddAddress(CreateAddressRequest request)
        {
            Address address = new Address()
            {
                HotelId = request.HotelId,
                CountryId = request.CountryId,
                CityId = request.CityId,
                Street = request.Street,
                StreetNumber = request.StreetNumber
            };

            List<Address> HotelAddress = new List<Address>();
            HotelAddress.Add(address);

            await _addressReporitory.AddAsync(address);

            return HotelAddress;
        }

        public async Task<List<Room>> AddRoom(CreateRoomRequest request)
        {
            Room room = new Room()
            {
                HotelId = request.HotelId,
                Name = request.Name,
                RoomAmount = request.RoomAmount,
                Smoke = request.Smoke,
                Price = request.Price,
                BasePerson = request.BasePerson,
                RoomTypeId = request.RoomTypeId,
                CouchetteId = request.CouchetteId,
                CreatedUtc = request.CreateDate
            };

            List<Room> rooms = new List<Room>();
            rooms.Add(room);

            await _roomReporitory.AddAsync(room);

            return rooms;
        }

        public async Task<List<HotelFoto>> AddFoto(CreateFotoRequest request)
        {
            HotelFoto foto = new HotelFoto()
            {
                HotelId = request.HotelId,
                Foto = request.Foto,
                CreatedUtc = DateTime.UtcNow
            };

            List<HotelFoto> fotos = new List<HotelFoto>();
            fotos.Add(foto);

            await _fotoReporitory.AddAsync(foto);

            return fotos;
        }

    }
}