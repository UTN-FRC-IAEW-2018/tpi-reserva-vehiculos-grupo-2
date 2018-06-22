using System;
namespace tp_api.InterfacesREST {
	public interface RESTIniciarSesion {
		void InicioExitoso(ref string mensaje);
		void InicioFallido(ref string mensaje);

	}

}
