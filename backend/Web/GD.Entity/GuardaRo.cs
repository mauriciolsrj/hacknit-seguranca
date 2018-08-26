using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Entity
{
    public class GuardaRo
    {
        public int Id { get; set; } // Id (Primary key)
        public string GuardaId { get; set; } // GuardaId (length: 128)
        public int IdRo { get; set; } // IdRO
    }
}
