using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.BL.HotelBL
{
    public class DaleteHotelDetailsServices
    {
        private readonly IRepository<Hotel, int> _hotelReporitory;
        private readonly IRepository<Room, int> _roomReporitory;
        private readonly IRepository<Address, int> _addressReporitory;

        public DaleteHotelDetailsServices(IRepository<Hotel, int> hotelReporitory,
            IRepository<Room, int> roomReporitory, IRepository<Address, int> addressReporitory)
        {
            _hotelReporitory = hotelReporitory;
            _roomReporitory = roomReporitory;
            _addressReporitory = addressReporitory;
        }
        public async Task<List<Hotel>> GetAll()
        {
            return await _hotelReporitory.GetAllAsync();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _hotelReporitory.GetByIdAsync(id);
        }
        public async Task<Response> DeleteHotel(int id)
        {
            _hotelReporitory.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
        public async Task<Response> DeleteAddress(int id)
        {
            _addressReporitory.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
        public async Task<Response> DeleteRoom(int id)
        {
            _roomReporitory.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }
    }
}