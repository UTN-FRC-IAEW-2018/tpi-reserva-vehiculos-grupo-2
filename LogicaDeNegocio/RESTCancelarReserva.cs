using System;
namespace LogicaDeNegocio {
	public interface RESTCancelarReserva {
		void ReservaCancelada(ref string mensaje);
		void CancelacionFallida(ref string mensaje);

	}

}
