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

        public async Task<Response> CreateHotel(CreateHotelRequest request)
        {
            Hotel hotel = new Hotel()
            {
                UserId= request.UserId,
                Name = request.Name,
                Description = request.Description,
                IsOne = request.IsOne,
                CheckingAccount = request.CheckingAccount,
                HotelTypeId = request.HotelTypeId,
                HotelCategoryId = request.HotelCategoryId,
                CreatedDate = request.CreateDate
            };

            await _hotelReporitory.AddAsync(hotel);


            return new Response(200, true, null);
        }

        public async Task<Response> AddLists(int hotelId, CreateAddressRequest Addressrequest,
            CreateRoomRequest roomRequest, CreateFotoRequest fotoRequest, ReviewRequest reviewRequest)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == hotelId);

            hotel.Addresses = await AddAddress(Addressrequest);
            hotel.ClientReviews = await _reviewsServices.GetAll();
            hotel.Rooms = await AddRoom(roomRequest);
            hotel.Fotos = await AddFoto(fotoRequest);
            hotel.ReviewStars = await _reviewsServices.HotelStars(reviewRequest);

            return new Response(200, true, null);
        } 

        public async Task<List<Address>> AddAddress(CreateAddressRequest request)
        {
            Address address = new Address()
            {
                CountryId = request.CountryId,
                CityId = request.CityId,
                Street = request.Street,
                StreetNumber = request.StreetNumber,
                CreatedDate= DateTime.UtcNow
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
                Name = request.Name,
                RoomAmount = request.RoomAmount,
                Smoke = request.Smoke,
                Price = request.Price,
                BasePerson = request.BasePerson,
                RoomTypeId = request.RoomTypeId,
                CouchetteId = request.CouchetteId,
                CreatedDate = DateTime.UtcNow,
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
                Foto = request.Foto,
                CreatedDate = DateTime.UtcNow
            };

            List<HotelFoto> fotos = new List<HotelFoto>();
            fotos.Add(foto);

            await _fotoReporitory.AddAsync(foto);

            return fotos;
        }

        //public async Task<List<HotelServices>> AddServices(AddHotelServices request)
        //{


        //    if(request == null)
        //    {
        //        throw new ArgumentNullException(nameof(request));
        //    }else 
        //    {
        //        var hotel = _context.Hotels.FirstOrDefault(h => h.Id == request.hotelId);

        //        foreach(int item in request.)
        //        {


        //        }

        //    }
            
        //    List<Room> rooms = new List<Room>();
        //    rooms.Add(room);

        //    await _roomReporitory.AddAsync(room);

        //    return rooms;
        //}



    }
}