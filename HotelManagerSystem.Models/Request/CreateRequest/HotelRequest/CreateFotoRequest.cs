﻿namespace HotelManagerSystem.Models.Request.CreateRequest.HotelRequest
{
    public class CreateFotoRequest
    {
        public int HotelId { get; set; }
        public string Foto { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}