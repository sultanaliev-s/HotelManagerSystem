using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class RoomType : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

    }
}