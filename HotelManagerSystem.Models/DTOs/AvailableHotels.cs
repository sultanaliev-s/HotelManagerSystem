using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.DTOs;

public class AvailableHotels
{
    public AvailableHotel Hotel { get; set; }
    public List<AvailableRoomsDto> AvailableRooms { get; set; }
}

public class AvailableHotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal ReviewStars { get; set; }
}
public class AvailableRoomsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Smoke { get; set; }
    public decimal Price { get; set; }
}