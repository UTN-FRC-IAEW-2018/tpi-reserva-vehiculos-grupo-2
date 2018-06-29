using System;
namespace LogicaDeNegocio {
	public interface RESTConsultarVehiculosDisponibles {
		void Paises(ref List<Pais> pai);
		void Ciudades(ref List<Ciudad> ciu);
		void VehiculosDisponibles(ref List<Vehiculo> veh);

	}

}
