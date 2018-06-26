using SOAP_Serv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clases;

namespace tp_api.Controllers
{
    [Produces("application/json")]
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
        [Route("api/vehiculos")]
        public IActionResult Get(int ciudad, DateTime desde, DateTime hasta)
        {
            ///api/vehiculos?ciudad=2&desde=2018-06-01T00:00:00&hasta=2018-06-31T23:59:59
            var service = WService.Service;

            var req = new ConsultarVehiculosRequest();
            req.FechaHoraRetiro = desde;
            req.FechaHoraDevolucion = hasta;
            req.IdCiudad = ciudad;

            var result =  service.ConsultarVehiculosDisponiblesAsync(WService.Credential, req).Result;

            return Json(result.ConsultarVehiculosDisponiblesResult.VehiculosEncontrados);
        }
        
    }
}
