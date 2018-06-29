using System;
namespace LogicaDeNegocio {
	public class Ciudad {
		private int codigoCiudad;
		private string nombre;
		private Pais pais;
		private List<DisponibilidadProveedor> vehiculosDisponibles;

		public Ciudad() {
			throw new System.Exception("Not implemented");
		}
		public bool AsociarVehiculoDisponible(ref Vehiculo veh, ref DateTime fecret, ref DateTime fecdev) {
			throw new System.Exception("Not implemented");
		}

		private DisponibilidadProveedor[] disponibilidadProveedors;

		private Vehiculo vehiculo;

	}

}
