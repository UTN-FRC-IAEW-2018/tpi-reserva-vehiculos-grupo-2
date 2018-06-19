using System;
namespace LogicaDeNegocio {
	public class Cliente {
		private int nroDocumento;
		private string nombre;
		private string apellido;
		private List<Reserva> reservas;
		private Usuario usuario;

		public Cliente() {
			throw new System.Exception("Not implemented");
		}
		public void SetUsuario(ref Usuario usu) {
			throw new System.Exception("Not implemented");
		}
		public bool ResrvarVehiculo(ref Vehiculo veh, ref DateTime fecret, ref DateTime fecdev, ref Lugar lugret, ref Lugar lugdev) {
			throw new System.Exception("Not implemented");
		}
		public void RegistrarCodigoReserva(ref int cod) {
			throw new System.Exception("Not implemented");
		}
		public bool EsCliente(ref int nrodoc) {
			throw new System.Exception("Not implemented");
		}
		public void SetReservas(ref List<Reserva> res) {
			throw new System.Exception("Not implemented");
		}
		public bool CancelarReserva(ref Reserva res, ref DateTime feccan) {
			throw new System.Exception("Not implemented");
		}
		public void BuscarReserva(ref Reserva res) {
			throw new System.Exception("Not implemented");
		}

	}

}
