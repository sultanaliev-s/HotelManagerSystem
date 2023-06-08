using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Entities.Relations;

namespace HotelManagerSystem.BL.HotelBL
{
    public class UpdateHotelDetalisServices
    {
        private readonly IRepository<Hotel, int> _hotelReporitory;
        private readonly IRepository<HotelsServices, int> _hotelsServicesReporitory;

        public UpdateHotelDetalisServices(IRepository<Hotel, int> hotelReporitory,
            IRepository<HotelsServices, int> hotelsServicesReporitory)
        {
            _hotelReporitory = hotelReporitory;
            _hotelsServicesReporitory = hotelsServicesReporitory;
        }



        public async Task<Response> UpdateHotel(int id, HotelDto dto)
        {
            var hotel = await _hotelReporitory.GetByIdAsync(id);

            var oldServicesIds = hotel.Services.Select(x => x.Id);

            var onCreateServicesIds = dto.ServicesIds.Except(oldServicesIds);

            var onDeleteServiceIds = oldServicesIds.Except(dto.ServicesIds);

            foreach (var onDeleteServicesId in onDeleteServiceIds)
            {
                await _hotelsServicesReporitory.DeleteByIdAsync(onDeleteServicesId);
            }

            foreach (var serviceId in onCreateServicesIds)
            {
                var newService = new HotelsServices
                {
                    HotelId = hotel.Id,
                    ServiceId = serviceId
                };

                await _hotelsServicesReporitory.AddAsync(newService);
            }

            return new Response(200, true, null);
        }
    }
}
