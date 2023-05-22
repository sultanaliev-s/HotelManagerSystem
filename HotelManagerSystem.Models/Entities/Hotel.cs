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
        // public int UserId {get; set;} 
        // public User User {get; set;}



        public int AddressId { get; set; }
        public Address Address { get; set; }
        List<Room> Rooms { get; set; }


    }
}