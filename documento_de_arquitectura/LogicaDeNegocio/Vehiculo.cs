using System;
namespace LogicaDeNegocio {
	public class Vehiculo {
		private int codigoVehiculo;
		private string modelo;
		private string marca;
		private string puntaje;
		private bool tieneAireAcon;
		private bool tieneDirecccion;
		private int cantidadPuertas;
		private double percioPorDia;
		private string tipoCambio;
		private Ciudad ciudad;

		public Vehiculo() {
			throw new System.Exception("Not implemented");
		}
		public double CalcularPrecioAlquiler() {
			throw new System.Exception("Not implemented");
		}

		private DisponibilidadProveedor disponibilidadProveedor;
		private Reserva reserva;

	}

}
