using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelManagerSystem.Models.Entities
{
    public class Сouchette : BaseEntity<int>
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}