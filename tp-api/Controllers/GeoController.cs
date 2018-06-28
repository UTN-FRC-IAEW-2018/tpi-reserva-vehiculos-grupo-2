
using System.Net;
using System.Net.Security;
using System.Web;
using System.Net.Http;
using SOAP_Serv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using RestSharp;
using Clases;

namespace tp_api.Controllers
{
    [Route("api/geo")]
    public class GeoController : Controller
    {
        // GET: api/Paises
        [HttpGet, Route("pais")]
        [Produces("application/json")]
        public JsonResult ConsultarPaises()
        {
            var service = WService.Service;
            ConsultarPaisesResponse1 result = service.ConsultarPaisesAsync(WService.Credential).Result;
            
            return Json(result.ConsultarPaisesResult.Paises);
        }

        
        [HttpGet("{pais:int}"), Route("ciudad")]
        [Produces("application/json")]
        public JsonResult ConsultarCiudades([FromRoute] int pais)
        {
            var service = WService.Service;

            var req = new ConsultarCiudadesRequest();
            req.IdPais = pais;

            var result = service.ConsultarCiudadesAsync(WService.Credential, req).Result.ConsultarCiudadesResult;
            
            return Json(result.Ciudades);
        }


    }
}
