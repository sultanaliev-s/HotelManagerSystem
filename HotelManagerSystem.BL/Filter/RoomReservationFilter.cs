﻿using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.Search;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelManagerSystem.BL.Filter
{
    public class RoomReservationFilter
    {
        private readonly IRepository<Hotel, int> _repository;
        private readonly IRepository<City, int> _cityRepository;
        private readonly IRepository<Address, int> _addressRepository;
        private readonly IRepository<RoomReservation, int> _reservationRepository;

        public RoomReservationFilter(IRepository<Hotel, int> repository,
            IRepository<City, int> cityRepository, IRepository<RoomReservation, int> reservationRepository, IRepository<Address, int> addressRepository)
        {
            _repository = repository;
            _cityRepository = cityRepository;
            _addressRepository = addressRepository;
            _reservationRepository = reservationRepository;
        }

        //дописать... 

        public async Task<List<Hotel>> Filter(FilterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            IQueryable<Hotel> query = _repository.GetQuery();


            var finish = await query.Where(c => c.cityId == request.CityId).Include(r => r.Rooms)
                .ThenInclude(r => r.Reservation)
                .Where(r => r.Rooms.Where(r => r.Reservation.ReserveStart >= request.startDate && r.Reservation.ReserveEnd <= request.endDate && r.BasePerson >= request.Persons) !=null)
                .AsNoTracking().ToListAsync();

            return finish;
        }
    }
}   
