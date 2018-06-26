using System;
using System.Collections.Generic;

namespace Models {
	public class Cliente {
		
		public int ClienteId { get; set; }
		public int NroDocumento { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
/*
		private List<Reserva> reservas;

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
*/
	}

}
