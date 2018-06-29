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
    public class ClientesController : Controller
    {
        private Context _context;
        public ClientesController(Context context)
        {
            _context = context;
        }

        // GET api/clientes/37821733/reservas
        [HttpGet, Route("{dni}/reservas")]
        public IActionResult ListarReservas([FromRoute] long dni)
        {
            var reservas = getReservas(dni);
            return Json(reservas);
        }

        //ESTE METODO NO ESTÁ EN USO. SE PODRÍA DEPRECAR
        // GET api/clientes/37821733/reservas/2
        [HttpGet, Route("{dni}/reservas/{id}")]
        public IActionResult MostrarReserva([FromRoute] long dni, [FromRoute] int id)
        {
            var reserva = getReserva(dni, id);
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
        [HttpPost, Route("{dni}/reservas")]
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

        // Asi es como tiene que estar armado el JSON para crear una reserva.
        public class CrearReservaPOSTRequest
        {
            public string token { get; set; }
            public DateTime desde { get; set; }
            public DateTime hasta { get; set; }
            //Los lugares pueden ser: [M, H, A]
            public string lugarOrigen { get; set; }
            public string lugarDestino { get; set; }
            public int idVehCiud { get; set; }
        }

        
        // DELETE api/clientes/37821733/reservas/321
        [HttpDelete("{dni}/reservas/{id}")]
        public IActionResult CancelarReserva([FromRoute] long dni, [FromRoute] int id)
        {
            var reserva = getReserva(dni, id);
            if (reserva == null)
                return NotFound("No se encontro");


            var service = WService.Service;
            var req = new CancelarReservaRequest();
            req.CodigoReserva = reserva.Codigo;

            var task = service.CancelarReservaAsync(WService.Credential, req);
            var response = task.Result;
            
            //Guardamos el estado actual.
            reserva.FechaCancelacion = response.CancelarReservaResult.Reserva.FechaCancelacion;
            _context.SaveChanges();

            Object[] ar = new Object[] { reserva, response.CancelarReservaResult.Reserva };
            return Json(ar);
        }

        //Metodos Privados.
        private Reserva getReserva(long dni, int id)
        {
            return getReservas(dni).Where(x => x.Id == id).FirstOrDefault();
        }


        private List<Reserva> getReservas(long dni)
        {
            var us_controller = new UsuariosController(_context);
            var us = us_controller.GetByDni(dni);

            if (us == null)
                return new List<Reserva>();

            var res_controller = new ModelsControllers.ReservasController(_context);
            return res_controller.GetByUsuario(us);
        }
      
        
    }
}
