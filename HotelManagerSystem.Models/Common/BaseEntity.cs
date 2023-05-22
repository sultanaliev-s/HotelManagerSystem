using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Data
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        //public bool IsDeleted { get; set; }
        public DateTime? DeletedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public DateTime CreatedUtc { get; set; }

    }
}
