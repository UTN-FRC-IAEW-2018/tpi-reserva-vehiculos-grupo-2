﻿using Clases;
using Microsoft.AspNetCore.Mvc;

namespace tp_api.Controllers
{
    
    [Route("api/lugares")]
    public class LugaresController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetLugares()
        {
            return Json(Lugar.getList());
        }

    }
}