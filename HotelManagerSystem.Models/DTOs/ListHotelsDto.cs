using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Entities.Relations;
using HotelManagerSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.DTOs;

public class ListHotelsDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
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
}

public class HotelCityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}

public class TypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class AddressDto
{
    public int Id { get; set; }
    public AddressCountryDto Countries { get; set; }
    public HotelCityDto Cities { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
}

public class AddressCountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class FotoDto
{
    public int Id { get; set; }
    public string Foto { get; set; }
}
