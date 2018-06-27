using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Clases;
using Microsoft.AspNetCore.Mvc;

namespace tp_api.Controllers
{
    [Produces("application/json")]
    [Route("api/lugares")]
    public class LugaresController : Controller
    {
        public IActionResult Get(int dni)
        {
            List<Lugar> values = new List<Lugar>()
            {
                new Lugar(){ Id = "H", Nombre = "Hotel" },
                new Lugar(){ Id = "A", Nombre = "Aeropuerto"},
                new Lugar(){ Id = "T", Nombre = "TerminalBus"}
            };
            return Json(values);
        }

        
    }
}