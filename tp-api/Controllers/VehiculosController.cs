using SOAP_Serv;
using System;
using Microsoft.AspNetCore.Mvc;
using Clases;

namespace tp_api.Controllers
{
    [Route("api/vehiculos")]
    public class VehiculosController : Controller
    {
        /// <summary>
        /// Consulta de Vehiculos Disponibles
        /// Desde Javascript usando moment.js:
        /// dateStart = moment(startDate).format('YYYY-MM-DDTHH:mm:ss');
        /// </summary>
        /// <param name="ciudad">id de ciudad</param>
        /// <param name="desde">desde: 'YYYY-MM-DDTHH:mm:ss' (2016-12-31T23:59:59)</param>
        /// <param name="hasta">hasta: 'YYYY-MM-DDTHH:mm:ss' (2016-12-31T23:59:59)</param>
        /// <returns></returns>
        [HttpGet, Produces("application/json")]
        public IActionResult ConsultarVehiculosDisponibles([FromQuery] int ciudad, [FromQuery] DateTime desde, [FromQuery] DateTime hasta)
        {
            /// GET api/vehiculos?ciudad=2&desde=2018-06-01T00:00:00&hasta=2018-06-31T23:59:59
            var service = WService.Service;

            var req = new ConsultarVehiculosRequest();
            req.FechaHoraRetiro = desde;
            req.FechaHoraDevolucion = hasta;
            req.IdCiudad = ciudad;

            var result =  service.ConsultarVehiculosDisponiblesAsync(WService.Credential, req).Result;

            var vehiculos = result.ConsultarVehiculosDisponiblesResult.VehiculosEncontrados;

            foreach(var v in vehiculos)
                v.PrecioPorDia *= (decimal)1.20;

            return Json(vehiculos);
        }

        
        
    }
}
