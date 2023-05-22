using HotelManagerSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelManagerSystem.Models.Entities
{
    public class HotelCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}