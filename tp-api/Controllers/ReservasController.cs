using SOAP_Serv;
using Clases;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Models;

namespace tp_api.Controllers
{
    [Produces("application/json")]
    [Route("api/clientes")]
    public class ReservasController : Controller
    {
        private Context _context;
        public ReservasController(Context context)
        {
            _context = context;
        }


        // GET api/clientes/37821733/reservas
        [Route("{dni}/reservas")]
        public IActionResult Get(int dni)
        {
            var service = WService.Service;

            return null;
        }

        // POST api/clientes/37821733/reservas
        [HttpPost(), Route("{dni}/reservas")]
        public IActionResult CrearReserva([FromBody] CrearReservaPOSTRequest input)
        {
            var service = WService.Service;
            var req = new ReservarVehiculoRequest();

            var controller = new UsuariosController(_context);
            var us = controller.GetByUsername(input.username);
            if (us == null)
                return NotFound("Usuario no encontrado");

            //Datos Cliente.
            req.ApellidoNombreCliente = $"{us.Apellido}, {us.Nombre}";
            req.NroDocumentoCliente = us.DNI.ToString();

            //Datos Retiro
            req.FechaHoraRetiro = input.desde;
            req.LugarRetiro = Lugar.getWSLugar(input.lugarOrigen);

            //Datos Devolucion
            req.FechaHoraDevolucion = input.hasta;
            req.LugarDevolucion = Lugar.getWSLugar(input.lugarDestino);

            req.IdVehiculoCiudad = input.idVehCiud;

            var result = service.ReservarVehiculoAsync(WService.Credential, req).Result.ReservarVehiculoResult;

            //Reserva devuelta
            var soap_reserva = result.Reserva;

            var db_reserva = new Reserva();

            db_reserva.Codigo = soap_reserva.CodigoReserva;
            db_reserva.DNI = us.DNI;
            db_reserva.ExtId = soap_reserva.Id;
            db_reserva.FechaDevolucion = soap_reserva.FechaHoraDevolucion;
            db_reserva.FechaRetiro = soap_reserva.

            



            //return Json(result.ReservarVehiculoResult.Reserva.Id);
            return null;
        } 
        public class CrearReservaPOSTRequest
        {
            public string username { get; set; }
            public DateTime desde { get; set; }
            public DateTime hasta { get; set; }
            public string lugarOrigen { get; set; }
            public string lugarDestino { get; set; }
            public int idVehCiud { get; set; }
        }

        
        // DELETE api/clientes/37821733/reservas/321
        [HttpDelete(), Route("{dni}/reservas/{reserva}")]
        public IActionResult Post([FromBody]string value)
        {
            return null;
        }


        
        
    }
}
