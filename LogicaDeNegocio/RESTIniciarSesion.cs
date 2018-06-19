using System;
namespace LogicaDeNegocio {
	public interface RESTIniciarSesion {
		void InicioExitoso(ref string mensaje);
		void InicioFallido(ref string mensaje);

	}

}
