using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using HotelManagerSystem.Models.Common;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Data
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
