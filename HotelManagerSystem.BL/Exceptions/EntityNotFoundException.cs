using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerSystem.BL.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public string Message { get; set; }

        public EntityNotFoundException() { Message = $"{typeof(T).Name} not found."; }
    }
}
