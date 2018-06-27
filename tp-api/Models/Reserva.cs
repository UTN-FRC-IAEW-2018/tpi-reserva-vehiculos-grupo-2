using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ExtId { get; set; }
        public string Codigo { get; set; }
        //public string Estado { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaRetiro { get; set; }
        public string LugarRetiro { get; set; }
        public string LugarDevolucion { get; set; }
        public decimal TotalReserva { get; set; }
        public decimal TotalReservaPropia { get; set; }
        public int VehiculoXCiudadId { get; set; }

        public int UserId { get; set; }
        public long DNI { get; set; }
    }
}
