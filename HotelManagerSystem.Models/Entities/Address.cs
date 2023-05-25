using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelManagerSystem.Models.Entities
{
    public class Address : BaseEntity<int>
    {  
        public int Country { get; set; }
        public Country Countries { get; set; }
        public int CityId { get; set; }
        public City Cities { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}