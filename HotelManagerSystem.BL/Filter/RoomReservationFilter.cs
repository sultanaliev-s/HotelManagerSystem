using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.Common;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.Search;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.BL.Filter
{
    public class RoomReservationFilter
    {
        private readonly IRepository<Hotel, int> _repository;
        private readonly HotelContext _context;

        public RoomReservationFilter(IRepository<Hotel, int> repository, HotelContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<List<AvailableHotels>> Filter(FilterRequest? request)
        {
            if (request == null)
            {
                throw new BadRequestException("Request cannot be null");
            }

            request.startDate = request.startDate.SetKindUtc();
            request.endDate = request.endDate.SetKindUtc();
            var city = _context.Cities.FirstOrDefault(x => x.Name.ToLower() == request.City.ToLower());
            if (city == null)
                throw new EntityNotFoundException<City>();


            IQueryable<Hotel> query = _repository.GetQuery();

            var hotelsWithAvailableRooms = await query
                .Where(hotel => hotel.cityId == city.Id)
                .Select(hotel => new
                {
                    Hotel = hotel,
                    AvailableRooms = hotel.Rooms.Where(room =>
                        room.BasePerson >= request.Persons &&
                        room.Reservations.Where(reservation =>
                            (reservation.ReserveStart <= request.endDate && reservation.ReserveEnd >= request.startDate) &&
                            (reservation.ReserveStart >= request.startDate && reservation.ReserveEnd <= request.endDate) &&
                            (reservation.ReserveEnd >= request.startDate && reservation.ReserveEnd <= request.endDate)
                        ).Count() < room.RoomAmount)
                })
                .Where(hotelData => hotelData.AvailableRooms.Any())
                .AsNoTracking()
                .ToListAsync();



            return hotelsWithAvailableRooms.Adapt<List<AvailableHotels>>();
        }
    }
}
