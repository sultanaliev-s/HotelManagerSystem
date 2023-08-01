using HotelManagerSystem.BL.Exceptions;
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
        public async Task DeleteHotel(int id)
        {
            var hotel = await _hotelReporitory.GetByIdAsync(id);
            if (hotel == null)
                throw new EntityNotFoundException<Hotel>();
            await _hotelReporitory.DeleteByIdAsync(id);
        }
        public async Task DeleteAddress(int id)
        {
            var addres = await _addressReporitory.GetByIdAsync(id);
            if (addres == null)
                throw new EntityNotFoundException<Address>();
            await _addressReporitory.DeleteByIdAsync(id);

        }
        public async Task DeleteRoom(int id)
        {
            var room = await _roomReporitory.GetByIdAsync(id);
            if (room == null)
                throw new EntityNotFoundException<Room>();
            await _roomReporitory.DeleteByIdAsync(id);
        }
    }
}