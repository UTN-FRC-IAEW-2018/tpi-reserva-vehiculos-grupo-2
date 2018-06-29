using System;
namespace LogicaDeNegocio {
	public interface RESTReservarVehiculo {
		void ReservaRegistrada(ref string mensaje);
		void RegistroFallido(ref string mensaje);
		void Cliente(ref Cliente cli);

	}

}
