using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelManagerSystem.Models.Entities
{
    public class Hotel : BaseEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReviewStars { get; set; }

 
        public int HotelTypeId { get; set; }
        public HotelType Type { get; set; }
        public int HotelCategoryId { get; set; }
        public HotelCategory Category { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Room> Rooms { get; set; }
        public List<HotelServices> Services { get; set; }
        public List<ClientReview> ClientReviews { get; set; }
        public List<HotelFoto> Fotos { get; set; }
    }
}