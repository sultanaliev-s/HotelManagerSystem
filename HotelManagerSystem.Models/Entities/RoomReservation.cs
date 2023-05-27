using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class RoomReservation : BaseEntity<int>
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public decimal Price { get; set; }
        public DateTime ReserveStart { get; set; }
        public DateTime ReserveEnd { get; set; }
        public int Person { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}