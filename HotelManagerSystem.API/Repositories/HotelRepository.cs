using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagerSystem.API.Repositories;
using HotelManagerSystem.DAL;
using HotelManagerSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.API.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelContext _context;

    public HotelRepository(HotelContext context)
    {
        _context = context;
    }

    public async Task<Hotel> GetHotelById(int hotelId)
    {
        return await _context.Hotels.FindAsync(hotelId);
    }

    public async Task<List<Hotel>> GetAllHotels()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task UpdateHotelBalance(int hotelId, string newBalance)
    {
        var hotel = await _context.Hotels.FindAsync(hotelId);
        hotel.CheckingAccount = newBalance;
        _context.Hotels.Update(hotel);
        await _context.SaveChangesAsync();
    }
}