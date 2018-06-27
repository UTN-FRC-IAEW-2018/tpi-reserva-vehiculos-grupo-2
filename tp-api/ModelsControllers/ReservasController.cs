using SOAP_Serv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace tp_api.ModelsControllers
{
    public class ReservasController : Controller
    {
        private readonly Context _context;

        public ReservasController(Context context)
        {
            _context = context;
        }

        public List<Reserva> GetByUsuario(Usuario us)
        {
            return _context.Reservas.Where(x => x.UserId == us.UsuarioId).ToList();
        }

        public Reserva Crear(ReservaEntity soap_reserva, Usuario us)
        {
            var db_reserva = new Reserva();

            db_reserva.Codigo = soap_reserva.CodigoReserva;
            db_reserva.DNI = us.DNI;
            db_reserva.ExtId = soap_reserva.Id;
            db_reserva.FechaDevolucion = soap_reserva.FechaHoraDevolucion;
            db_reserva.FechaRetiro = soap_reserva.FechaHoraRetiro;
            db_reserva.LugarDevolucion = soap_reserva.LugarDevolucion;
            db_reserva.LugarRetiro = soap_reserva.LugarRetiro;
            db_reserva.TotalReserva = soap_reserva.TotalReserva;
            db_reserva.TotalReservaPropia = soap_reserva.TotalReserva * (decimal)1.2;
            db_reserva.UserId = us.UsuarioId;
            db_reserva.VehiculoXCiudadId = soap_reserva.VehiculoPorCiudadId;

            _context.Reservas.Add(db_reserva);
            _context.SaveChanges();

            return db_reserva;
        }
    }
}