using HotelManagerSystem.DAL;
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


        public async Task<List<Hotel>> Filter(FilterRequest request)
        {
            IQueryable<Hotel> query = _repository.GetQuery();

            var cityList = query.Include(x => x.Addresses).ThenInclude(x => x.CityId).Where(x => x.Id == request.CityId);

            var reservationEnd = query.Include(r => r.Rooms)
                .ThenInclude(d => d.Reservation).ThenInclude(d => d.ReserveEnd <= request.endDate && d.ReserveStart >= request.startDate);

            var reservationStart = query.Include(r => r.Rooms)
                .ThenInclude(r => r.Reservation).ThenInclude(r => r.ReserveEnd <= request.endDate);


            if (request == null || reservationStart == null || reservationEnd == null || request.Persons == 0 || cityList == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");

                return await _repository.GetAllAsync();
            }

            List<Hotel> result = await query.AsNoTracking().ToListAsync();
            return result;
        }

    }
}
