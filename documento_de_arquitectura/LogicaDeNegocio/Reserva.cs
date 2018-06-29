using System;
namespace LogicaDeNegocio {
	public class Reserva {
		private int codigoReserva;
		private Vehiculo vehiculo;
		private DateTime fechaRetriro;
		private DateTime fechaDevolucion;
		private DateTime fechaCancelacion;
		private Lugar lugarRetiro;
		private Lugar lugarDevolucion;
		private EstadoReserva estado;

		public Reserva() {
			throw new System.Exception("Not implemented");
		}
		public double CalcularTotalCliente() {
			throw new System.Exception("Not implemented");
		}
		public double CalcularTotalProveedor() {
			throw new System.Exception("Not implemented");
		}
		public void SetCodigoReserva(ref int cod) {
			throw new System.Exception("Not implemented");
		}
		public bool EsReserva(ref Reserva res) {
			throw new System.Exception("Not implemented");
		}
		public bool EstaActiva() {
			throw new System.Exception("Not implemented");
		}
		public void CancelarReserva(ref DateTime feccan) {
			throw new System.Exception("Not implemented");
		}

		private EstadoReserva estadoReserva;
		private Lugar lugar;

		private Cliente cliente;

	}

}
