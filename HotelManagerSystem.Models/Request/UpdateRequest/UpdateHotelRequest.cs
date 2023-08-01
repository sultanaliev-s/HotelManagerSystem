using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Request.UpdateRequest;

public class UpdateHotelRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsOne { get; set; }
    public string CheckingAccount { get; set; }
    public int FilialCount { get; set; }
    public int HotelTypeId { get; set; }
    public int HotelCategoryId { get; set; }
    public int CityId { get; set; }
}
