import React, { Component } from 'react';
import api from '../../api';


class ListaVehiculos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      vehiculos: [{id: 1, nombre: 'Algo', descripcion: 'Algo más', precio: '$230'}],
      error: undefined
    }
  }

  loadVehiculos() {
    api.get('/api/vehiculos/')
      .then(res => {
        const vehiculosData = res.data;
        this.setState({ vehiculos: vehiculosData, error:undefined});
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  componentDidMount() {
    this.loadVehiculos();
  }


  render() {
    const listaVehiculos = this.state.vehiculos.map((v) =>
      <tr>
        <td>{v.id}</td>
        <td>{v.nombre}</td>
        <td>{v.descripcion}</td>
        <td>{v.precio}</td>
      </tr>
    );
    return (
      <div>
        <h1>Lista de vehículos</h1>
        <span style={{color: "red"}}>{this.state.error}</span>
        <hr />
        <table class="table">
            <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Nombre</th>
                <th scope="col">Descripción</th>
                <th scope="col">Precio</th>
            </tr>
            </thead>
            <tbody>
            {listaVehiculos}
            </tbody>
        </table>
      </div>
    );
  }
}

export default ListaVehiculos;