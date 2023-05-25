using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HotelManagerSystem.Models.Common;


namespace HotelManagerSystem.Models.Entities
{
    public class HotelCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int HotelTypeId { get; set; }
        public HotelType HotelType { get; set; }
    }
}