using SOAP_Serv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tp_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Paises")]
    public class PaisesController : Controller
    {
        // GET: api/Paises
        [HttpGet]
        public JsonResult Get()
        {
            var service = new WCFReservaVehiculosClient();
            var credentials = new Credentials();
            credentials.UserName = "grupo_nro2";
            credentials.Password = "crkVYDPh";
            ConsultarPaisesResponse1 result = service.ConsultarPaisesAsync(credentials).Result;

            var json = new JsonResult(result.ConsultarPaisesResult.Paises);

            return json;
        }

    }
}
