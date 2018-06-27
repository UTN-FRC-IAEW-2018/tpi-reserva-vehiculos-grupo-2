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
            return Json(Lugar.getList());
        }

        
    }
}