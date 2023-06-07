﻿using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;

namespace HotelManagerSystem.DAL.Responses
{
    public class HotelsListResponse : Response
    {
        public HotelsListResponse(int statusCode, bool success , string message, List<Hotel> hotels)
            : base(statusCode, success, message)
        {
            Departments = hotels.Select(dep => new HotelDto(dep)).ToList();
        }

        public List<HotelDto> Departments { get; set; }
    }
}
