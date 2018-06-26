using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int UserId { get; set; }
        public long DNI { get; set; }
    }
}
