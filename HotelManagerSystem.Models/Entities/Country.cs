using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Data
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<City> Cities { get; set;}
    }
}
