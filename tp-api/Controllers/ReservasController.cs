using SOAP_Serv;
using Clases;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace tp_api.Controllers
{
    [Produces("application/json")]
    [Route("api/clientes")]
    public class ReservasController : Controller
    {
        // GET api/clientes/37821733/reservas
        [Route("{dni}/reservas")]
        public IActionResult Get(int dni)
        {
            var service = WService.Service;

            return null;
        }

        // POST api/clientes/37821733/reservas
        [HttpPost(), Route("{dni}/reservas")]
        public IActionResult CrearReserva(int id)
        {
            var service = WService.Service;

            var req = new ReservarVehiculoRequest();
            
            req.LugarRetiro = LugarRetiroDevolucion.Aeropuerto;
            req.NroDocumentoCliente = "321";
            
            var result = service.ReservarVehiculoAsync(WService.Credential, req).Result.ReservarVehiculoResult;
            var reserva = result.Reserva;
            //            reserva.

            //return Json(result.ReservarVehiculoResult.Reserva.Id);
            return null;
        }
        
        // DELETE api/clientes/37821733/reservas/321
        [HttpDelete(), Route("{dni}/reservas/{reserva}")]
        public IActionResult Post([FromBody]string value)
        {
            return null;
        }
        
    }
}
