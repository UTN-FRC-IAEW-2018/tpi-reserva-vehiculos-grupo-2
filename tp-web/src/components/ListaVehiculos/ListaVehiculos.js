import React, { Component } from 'react';


class ListaVehiculos extends Component {
  constructor(props) {
    super(props);
    if (!localStorage.getItem("token")) { this.props.history.push('')}
    this.state = {
      error: undefined
    }
  }

  getPuntaje(puntaje) {
    let cadena = "";
    for (let i=0; i < puntaje; i++) {
      cadena += '*';
    }
    return cadena;
  }
  
 
  render() {
    if (this.props.vehiculos) {
      const listaVehiculos = this.props.vehiculos.map((v) =>
        <tr>
          <td>{v.marca}</td>
          <td>{v.modelo}</td>
          <td>{this.getPuntaje(v.puntaje)}</td>
          <td>{v.tieneAireAcon ? "Sí" : "No"}</td>
          <td>{v.tipoCambio === "M" ? "Manual" : "Automático"}</td>
          <td>{v.cantidadPuertas}</td>
          <td>{'$' + parseFloat(v.precioPorDia).toFixed(2)}</td>
          <button type="button" class="btn btn-warning" onClick={() => this.props.reservar(v)}>
            Reservar
          </button>
        </tr>
      );
      return (
        <div>
          <table class="table">
              <thead>
              <tr>
                <th scope="col">Marca</th>
                <th scope="col">Modelo</th>
                <th scope="col">Puntaje</th>
                <th scope="col">AA</th>
                <th scope="col">Cambio</th>
                <th scope="col">Puertas</th>
                <th scope="col">Precio por día</th>
                <th scope="col"></th>
              </tr>
              </thead>
              <tbody>
              {listaVehiculos}
              </tbody>
          </table>
        </div>
      );
    } else {
      return (<div></div>)
    }
  }
}

export default ListaVehiculos;