using System;
namespace ServiciosWeb {
	public class ControllerReservas : LogicaDeNegocio.RESTCancelarReserva , LogicaDeNegocio.RESTConsultarReservas , LogicaDeNegocio.RESTReservarVehiculo  {
		public IHttpActionResult Get(ref int nro_doc) {
			throw new System.Exception("Not implemented");
		}
		public IHttpActionResult Post(ref int nro_doc, ref Reserva reserva) {
			throw new System.Exception("Not implemented");
		}
		public IHttpActionResult Put(ref int nro_doc, ref Reserva reserva) {
			throw new System.Exception("Not implemented");
		}
		public void CancelacionFallida(ref string mensaje) {
			throw new System.Exception("Not implemented");
		}
		public void ReservaCancelada(ref string mensaje) {
			throw new System.Exception("Not implemented");
		}
		public void Reservas(ref List<LogicaDeNegocio.Reserva> res) {
			throw new System.Exception("Not implemented");
		}
		public void Cliente(ref Cliente cli) {
			throw new System.Exception("Not implemented");
		}
		public void RegistroFallido(ref string mensaje) {
			throw new System.Exception("Not implemented");
		}
		public void ReservaRegistrada(ref string mensaje) {
			throw new System.Exception("Not implemented");
		}

	}

}
