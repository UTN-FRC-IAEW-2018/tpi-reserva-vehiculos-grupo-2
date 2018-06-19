using System;
namespace ServiciosWeb {
	public class ControllerClientes : LogicaDeNegocio.RESTRegistrarCliente  {
		public IHttpActionResult Get(ref int nro_doc) {
			throw new System.Exception("Not implemented");
		}
		public IHttpActionResult Post(ref Cliente cliente) {
			throw new System.Exception("Not implemented");
		}
		public void ClienteRegistrado(ref string mensaje) {
			throw new System.Exception("Not implemented");
		}

	}

}
