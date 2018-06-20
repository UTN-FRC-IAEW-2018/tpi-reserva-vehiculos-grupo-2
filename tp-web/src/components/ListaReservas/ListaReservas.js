import React, { Component } from 'react';
import api from '../../api';
import './ListaReservas.css';


class ListaReservas extends Component {
  constructor(props) {
    super(props);
    if (!localStorage.getItem("token")) { this.props.history.push('')}
    this.state = {
      reservas: [{id: 1, nombre: 'Algo', descripcion: 'Algo más', precio: '$230'}],
      error: undefined
    }
  }

  loadReservas() {
    api.get('/api/reservas/')
      .then(res => {
        const reservasData = res.data;
        this.setState({ reservas: reservasData, error: undefined});
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  componentDidMount() {
    this.loadReservas();
  }

  viewReserva(id) {
    this.props.history.push('reserva', { reserva_id: id });
  }

  deleteReserva(id) {
    api.delete('/api/reservas/' + id)
      .then(res => {
        this.loadReservas();
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  render() {
    const listaReservas = this.state.reservas.map((r) =>
      <tr>
        <td>{r.id}</td>
        <td>{r.nombre}</td>
        <td>{r.descripcion}</td>
        <td>{r.precio}</td>
        <button type="button" class="btn btn-success" onClick={() => this.viewReserva(r.id)}>
          Consultar
        </button>
        <button type="button" class="btn btn-danger" onClick={() => this.deleteReserva(r.id)}>
          Eliminar
        </button>
      </tr>
    );
    return (
      <div>
        <h1>Lista de reservas</h1>
        <span style={{color: "red"}}>{this.state.error}</span>
        <hr />
        <table class="table">
            <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Nombre</th>
                <th scope="col">Descripción</th>
                <th scope="col">Precio</th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
            </thead>
            <tbody>
            {listaReservas}
            </tbody>
        </table>
      </div>
    );
  }
}

export default ListaReservas;