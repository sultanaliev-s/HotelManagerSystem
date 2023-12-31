﻿using HotelManagerSystem.Models.Common;

namespace HotelManagerSystem.Models.Entities
{
    public class Room : BaseEntity<int>
    {
        public string Name { get; set; }
        public int RoomAmount { get; set; }
        public bool Smoke { get; set; }
        public decimal Price { get; set; }
        public int BasePerson { get; set; }
        public int PhotoId { get; set; }
        public HotelFoto? Photo { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Couchette> Couchettes { get; set; }
        public List<RoomReservation>? Reservations { get; set; }

    }
}