using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HotelManagerSystem.Models.Common;
using System.Text;

namespace HotelManagerSystem.Models.Entities
{
    public class Hotel : BaseEntity<int>
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReviewStars { get; set; }
        public bool IsOne { get; set; }
        public string CheckingAccount { get; set; }
        public int FilialCount { get; set; }
        

        public int HotelTypeId { get; set; }
        public HotelType Type { get; set; }
        public int HotelCategoryId { get; set; }
        public HotelCategory Category { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Room>? Rooms { get; set; }
        public List<ClientReview>? ClientReviews { get; set; }
        public List<HotelFoto>? Fotos { get; set; }
    }
}