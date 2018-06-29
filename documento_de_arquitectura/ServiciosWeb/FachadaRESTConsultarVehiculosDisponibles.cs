using System;
namespace ServiciosWeb {
	public class FachadaRESTConsultarVehiculosDisponibles : LogicaDeNegocio.RESTConsultarVehiculosDisponibles  {
		public void VehiculosDisponibles(ref List<LogicaDeNegocio.Vehiculo> veh) {
			throw new System.Exception("Not implemented");
		}
		public void Ciudades(ref List<LogicaDeNegocio.Ciudad> ciu) {
			throw new System.Exception("Not implemented");
		}
		public void Paises(ref List<LogicaDeNegocio.Pais> pai) {
			throw new System.Exception("Not implemented");
		}

		private ControllerPaises controllerPaises;
		private ControllerCiudades controllerCiudades;
		private ControllerVehiculos controllerVehiculos;

	}

}
