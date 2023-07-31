using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;

namespace HotelManagerSystem.BL.HotelBL
{
    public class CreateHotelDetailsServices
    {
        private readonly IRepository<Hotel, int> _hotelReporitory;
        private readonly IRepository<Room, int> _roomReporitory;
        private readonly IRepository<Address, int> _addressReporitory;
        private readonly UserReviewsServices _reviewsServices;
        private readonly HotelContext _context;

        public CreateHotelDetailsServices(IRepository<Hotel, int> hotelReporitory,
            IRepository<Room, int> roomReporitory, IRepository<Address, int> addressReporitory,
            UserReviewsServices reviewsServices, HotelContext context)
        {
            _hotelReporitory = hotelReporitory;
            _roomReporitory = roomReporitory;
            _addressReporitory = addressReporitory;
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

        public async Task<Response> CreateHotel(CreateHotelRequest request /*, ReviewRequest request1*/)
        {
            Hotel hotel = new Hotel()
            {
                UserId = request.UserId,
                Name = request.Name,
                Description = request.Description,
                IsOne = request.IsOne,
                CheckingAccount = request.CheckingAccount,
                HotelTypeId = request.HotelTypeId,
                HotelCategoryId = request.HotelCategoryId,
                //ReviewStars = request.ReviewStars = await _reviewsServices.HotelStars(request1),
                CreatedDate = request.CreateDate
            };

            await _hotelReporitory.AddAsync(hotel);

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
                CreatedDate = DateTime.UtcNow
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
    }
}