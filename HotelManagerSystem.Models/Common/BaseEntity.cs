using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.Models.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime? DeletedUtc { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
