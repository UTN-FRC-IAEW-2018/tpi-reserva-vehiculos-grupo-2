using System;
using Microsoft.AspNetCore.Mvc;
using Models;
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

		[HttpPost()]
		public IActionResult RegistrarCliente(string email, int nrodoc, string nom, string ape) {
			ClientesController controller = new ClientesController(_context);
			UsuariosController usuarioController = new UsuariosController(_context);
			Usuario usuario = usuarioController.Get(email);
			Cliente cliente = new Cliente {
				NroDocumento = nrodoc,
				Nombre = nom,
				Apellido = ape,
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
