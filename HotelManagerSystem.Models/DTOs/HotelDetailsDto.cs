using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelManagerSystem.Models.DTOs.RoomDto.RoomReservationDto;

namespace HotelManagerSystem.Models.DTOs;

public class HotelDetailsDto
{
    public int Id { get; set; }
    public UserDto User { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal ReviewStars { get; set; }
    public bool IsOne { get; set; }
    public string CheckingAccount { get; set; }
    public int FilialCount { get; set; }
    public HotelCityDto city { get; set; }
    public TypeDto Type { get; set; }
    public CategoryDto Category { get; set; }
    public List<AddressDto>? Addresses { get; set; }
    public List<FotoDto>? Fotos { get; set; }
    public List<RoomDto> Rooms { get; set; }
    public List<ClientReviewDto>? ClientReviews { get; set; }
    public List<HotelServiceDto> Services { get; set; }
}

public class RoomDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RoomAmount { get; set; }
    public bool Smoke { get; set; }
    public decimal Price { get; set; }
    public int BasePerson { get; set; }
    public RoomHotelTypeDto RoomType { get; set; }
    public List<CouchetteDto> Сouchettes { get; set; }
    public List<RoomReservationDto>? Reservations { get; set; }

    public class RoomHotelTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CouchetteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class RoomReservationDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public decimal Price { get; set; }
        public DateTime ReserveStart { get; set; }
        public DateTime ReserveEnd { get; set; }
        public int Person { get; set; }
    }
}

public class ClientReviewDto
{
    public int Id { get; set; }
    public UserDto User { get; set; }

    public int Stars { get; set; }
    public string Comment { get; set; }
}
public class HotelServiceDto
{
    public int Id { get; set; }
    public ServiceDto HotelService { get; set;}
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

public class UserDto
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

}


