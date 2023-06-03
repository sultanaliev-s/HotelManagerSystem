using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.API.Repositories;

public interface IHotelRepository
{
    Task<Hotel> GetHotelById(int hotelId);
    Task<List<Hotel>> GetAllHotels();
    Task UpdateHotelBalance(int hotelId, string newBalance);
}