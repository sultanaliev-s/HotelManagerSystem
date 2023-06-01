using HotelManagerSystem.DAL;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request;

namespace HotelManagerSystem.BL.Filter
{
    public class RoomReservationFilter
    {
        private readonly HotelContext _context;

        public RoomReservationFilter(HotelContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> Filter(FilterRequest request, List<Hotel> hotels)
        {
            if (string.IsNullOrEmpty(request.City))
            {
                throw new ArgumentException("Город не может быть пустым");
            }
            if (request.startDate >= request.endDate)
            {
                throw new ArgumentException("Дата въезда должна быть раньше даты выезда");
            }
            if (request.Persons <= 0)
            {
                throw new ArgumentException("Количество людей должно быть больше нуля");
            }

            List<Hotel> hotelsFilter = new List<Hotel>();

            //var cityTrue = _context.Hotels.Addresses.FirstOrDefault(c => c.Cities.Name == request.City);

            foreach (var hotel in hotels)
            {
                //if ()
                //{
                //    hotelsFilter.Add(hotel);
                //}
            }




            return hotels;

        }
        private bool IsAvailable(Hotel hotel, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
                
            return true;
        }
    }
}