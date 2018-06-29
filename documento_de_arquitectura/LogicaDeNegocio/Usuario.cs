using System;
namespace LogicaDeNegocio {
	public class Usuario {
		private string nombre;
		private string password;

		public Usuario() {
			throw new System.Exception("Not implemented");
		}
		public bool CerrarSesionActiva() {
			throw new System.Exception("Not implemented");
		}

		private Sesion[] sesions;

		private Cliente cliente;

	}

}
