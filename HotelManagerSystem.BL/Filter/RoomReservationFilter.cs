using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.Search;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.BL.Filter
{
    public class RoomReservationFilter
    {
        private readonly IRepository<Hotel, int> _repository;

        public RoomReservationFilter(IRepository<Hotel, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<Hotel>> Filter(FilterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            IQueryable<Hotel> query = _repository.GetQuery();

            var finish = await query
                .Include(x => x.Rooms)
                .ThenInclude(x => x.Reservations)
                .Where(x => x.cityId == request.CityId && x.Rooms
                    .Where(room => room.Reservations
                        .Where(x => x.ReserveStart >= request.startDate
                            && x.ReserveEnd <= request.endDate
                            && room.BasePerson >= request.Persons)
                        .Any())
                    .Any())
                .AsNoTracking()
                .ToListAsync();

            return finish;
        }
    }
}
