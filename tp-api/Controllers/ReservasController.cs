using Newtonsoft.Json.Linq;
using tp_api.ModelsControllers;
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
        public IActionResult Get(long dni)
        {
            var us_controller = new UsuariosController(_context);
            var us = us_controller.GetByDni(dni);

            if (us == null)
                return NotFound("No se encontro el usuario.");

            var res_controller = new ModelsControllers.ReservasController(_context);
            var reservas = res_controller.GetByUsuario(us);


            return Json(reservas);
        }

        // GET api/clientes/37821733/reservas/2
        [Route("{dni}/reservas/{id}")]
        public IActionResult Get(long dni, int id)
        {
            var us_controller = new UsuariosController(_context);
            var us = us_controller.GetByDni(dni);

            if (us == null)
                return NotFound("No se encontro el usuario.");

            var res_controller = new ModelsControllers.ReservasController(_context);
            var reservas = res_controller.GetByUsuario(us);

            var reserva = reservas.Where(x => x.Id == id).FirstOrDefault();
            if (reserva == null)
                return NotFound("No se encontro esa reserva, con ese usuario.");

            var service = WService.Service;
            var req = new ConsultarReservasRequest();
            req.CodigoReserva = reserva.Codigo;

            var result = service.ConsultarReservaAsync(WService.Credential, req).Result.ConsultarReservaResult;
            var soap_reserva = result.Reserva;

            Object[] ar = new Object[] { reserva, soap_reserva };


            return Json(ar);
        }

        // POST api/clientes/37821733/reservas
        [HttpPost(), Route("{dni}/reservas")]
        public IActionResult CrearReserva([FromBody] CrearReservaPOSTRequest input, [FromRoute] int dni)
        {
            var service = WService.Service;
            var req = new ReservarVehiculoRequest();

            //Traemos el Usuario segun el Token.
            var user_controller = new UsuariosController(_context);
            var us = user_controller.GetByToken(input.token);
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

            //Ejecutamos la llamada al servidor SOAP.
            var result = service.ReservarVehiculoAsync(WService.Credential, req).Result.ReservarVehiculoResult;

            //Reserva devuelta
            var soap_reserva = result.Reserva;

            //Guardamos en la DB.
            var reserva_controller = new ModelsControllers.ReservasController(_context);
            var db_reserva = reserva_controller.Crear(soap_reserva, us);

            //Devolvemos la reserva almacenada local.
            return Json(db_reserva);
        } 
        public class CrearReservaPOSTRequest
        {
            public string token { get; set; }
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
