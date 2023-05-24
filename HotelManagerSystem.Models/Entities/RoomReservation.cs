using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelManagerSystem.Models.Entities
{
    public class RoomReservation : BaseEntity<int>
    {
        //public int UserId
        //public User User 
        public decimal Price { get; set; }
        public DateTime ReserveStart { get; set; }
        public DateTime ReserveEnd { get; set; }
        public int Person { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}