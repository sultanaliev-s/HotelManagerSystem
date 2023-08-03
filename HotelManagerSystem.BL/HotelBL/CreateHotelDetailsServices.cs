﻿using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;
using Mapster;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CreateHotel(CreateHotelRequest request)
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
                ReviewStars = 0,
                CreatedDate = request.CreateDate,
                cityId = request.CityId,
            };

            var createdHotel = await _hotelReporitory.AddAsync(hotel);

            return createdHotel.Id;
        }

        public async Task<int> AddAddress(CreateAddressRequest request)
        {
            Address address = new Address()
            {
                CountryId = request.CountryId,
                CityId = request.CityId,
                Street = request.Street,
                StreetNumber = request.StreetNumber,
                CreatedDate = DateTime.UtcNow,
                HotelId = request.Hotel,
               
            };

            var createdAddress = await _addressReporitory.AddAsync(address);

            return createdAddress.Id;
        }

        public async Task<int> AddRoom(CreateRoomRequest request)
        {
            Room room = new Room()
            {
                Name = request.Name,
                RoomAmount = request.RoomAmount,
                Smoke = request.Smoke,
                Price = request.Price,
                BasePerson = request.BasePerson,
                RoomTypeId = request.RoomTypeId,
                CreatedDate = DateTime.UtcNow,
                HotelId = request.HotelId,
                Сouchettes = new List<Сouchette>()
            };
            foreach(var id in request.CouchettesIds)
            {
                var couchette = await _context.Couchettes.FindAsync(id);
                if (couchette == null)
                    throw new EntityNotFoundException<Сouchette>();
                room.Сouchettes.Add(couchette);
            }
            var createdRoom = await _roomReporitory.AddAsync(room);

            return createdRoom.Id;
        }

        public async Task<List<ListHotelsDto>> GettAllHotels()
        {
            var hotels = _context.Hotels
                .Include(x => x.Type)
                .Include(x => x.Category)
                .Include(x => x.city)
                .Include(x => x.Fotos)
                .Include(x => x.Addresses)
                    .ThenInclude(x => x.Countries)
                .Include(x => x.Addresses)
                    .ThenInclude(x => x.Cities);
            var result = hotels.Adapt<List<ListHotelsDto>>();   

            return result;
        }

        public async Task<HotelDetailsDto> GetHotelById(int id)
        {
            var hotel = await _context.Hotels.Where(x => x.Id == id)
                .Include(x => x.Type)
                .Include(x => x.Category)
                .Include(x => x.city)
                .Include(x => x.Fotos)
                .Include( x=> x.User)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.RoomType)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Сouchettes)
                .Include(x => x.Rooms)
                    .ThenInclude(x => x.Reservations)
                .Include( x=> x.ClientReviews)
                    .ThenInclude(x => x.User)
                .Include(x => x.Services)
                    .ThenInclude(x => x.HotelService)
                .Include(x => x.Addresses)
                    .ThenInclude(x => x.Countries)
                .Include(x => x.Addresses)
                    .ThenInclude(x => x.Cities)
                .AsSplitQuery()
                .FirstOrDefaultAsync();


            if (hotel == null)
                throw new EntityNotFoundException<Hotel>();

            var result = hotel.Adapt<HotelDetailsDto>();

            return result;
        }
    }
}