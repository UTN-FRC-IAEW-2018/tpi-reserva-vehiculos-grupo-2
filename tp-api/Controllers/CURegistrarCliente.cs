using System;
using Microsoft.AspNetCore.Mvc;
using Models;
using Clases;
using tp_api.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace tp_api.Controllers {
	[Route("api/clientes")]
	public class CURegistrarCliente : Controller {

		private readonly Context _context;

		public CURegistrarCliente(Context context)
        {
            _context = context;
        }

		[Produces("application/json")]
        [Route("new"), HttpPost()]
        public IActionResult Post([FromBody] NuevoCliente input) {
			ClientesController controller = new ClientesController(_context);
			UsuariosController usuarioController = new UsuariosController(_context);
			Usuario usuario = usuarioController.Get(input.email);
			Cliente cliente = new Cliente {
				NroDocumento = input.nrodoc,
				Nombre = input.nom,
				Apellido = input.ape,
				UsuarioId = usuario.UsuarioId
			};
			controller.CrearCliente(cliente);
			return Json(cliente);
		}
		public void CrearCliente() {
			throw new System.Exception("Not implemented");
		}
		public void PersistirDatos() {
			throw new System.Exception("Not implemented");
		}

	}

}
