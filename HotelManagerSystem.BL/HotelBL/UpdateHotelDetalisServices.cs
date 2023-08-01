using HotelManagerSystem.BL.Review;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Entities.Relations;
using HotelManagerSystem.Models.Request.CreateRequest.HotelRequest;
using System.Xml.Linq;
using HotelManagerSystem.Models.Request.UpdateRequest;
using System.Linq;
using HotelManagerSystem.BL.Exceptions;

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

        public async Task<Response> UpdateHotel(UpdateHotelRequest request)
        {
            Hotel hotel = await _hotelReporitory.GetByIdAsync(request.Id);
            if (hotel == null)
                throw new EntityNotFoundException<Hotel>();
           
            hotel.Name = request.Name;
            hotel.Description = request.Description;
            hotel.IsOne = request.IsOne;
            hotel.CheckingAccount = request.CheckingAccount;
            hotel.HotelTypeId = request.HotelTypeId;
            hotel.HotelCategoryId = request.HotelCategoryId;

            await _hotelReporitory.UpdateAsync(hotel);

            return new Response(200, true, null);
        }

        public async Task<Response> UpdateHotelServices(UpdateHotelServicesRequest request)
        {
            var hotel = await _hotelReporitory.GetByIdAsync(request.Id);
            if (hotel == null)
                throw new EntityNotFoundException<Hotel>();

            var oldServicesIds = (await _hotelsServicesReporitory.GetByPredicate(x => x.HotelId == request.Id)).ToList().Select(x => x.HotelServiceId);

            var onCreateServicesIds = request.HotelServicesId.Except(oldServicesIds);

            var onDeleteServiceIds = oldServicesIds.Except(request.HotelServicesId);

            foreach (var onDeleteServicesId in onDeleteServiceIds)
            {
                await _hotelsServicesReporitory.DeleteByIdAsync(onDeleteServicesId);
            }

            foreach (var serviceId in onCreateServicesIds)
            {
                var newService = new HotelsServices
                {
                    HotelId = hotel.Id,
                    HotelServiceId = serviceId
                };

                await _hotelsServicesReporitory.AddAsync(newService);
            }

            return new Response(200, true, null);
        }
    }
}
