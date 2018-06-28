import React, { Component } from 'react';
import moment from 'moment';
import api from '../../api';
import VerReserva from '../VerReserva/VerReserva';
import './ListaReservas.css';


class ListaReservas extends Component {
  constructor(props) {
    super(props);
    if (!localStorage.getItem("token")) { this.props.history.push('') }
    this.state = {
      reservas: [{ id: 1, nombre: 'Algo', descripcion: 'Algo más', precio: '$230' }],
      error: undefined
    }
    this.handleReturn = this.handleReturn.bind(this);
  }

  loadReservas() {
    api.get('/clientes/' + localStorage.getItem("dni") + '/reservas')
      .then(res => {
        const reservasData = res.data;
        console.log(res.data);
        this.setState({ reservas: reservasData, error: undefined });
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  componentDidMount() {
    this.loadReservas();
  }

  viewReserva(reserva) {
    this.setState({ reserva: reserva });
  }

  handleReturn() {
    this.setState({ reserva: undefined });
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
    if (this.state.reserva) {
      return(
        <VerReserva reserva={this.state.reserva} return={this.handleReturn} />
      )
    } else {
      const listaReservas = this.state.reservas.map((r) =>
        <tr>
          <td>{r.codigo}</td>
          <td>{moment(r.fechaRetiro).format('DD/MM/YYYY HH:mm')}</td>
          <td>{r.lugarRetiro}</td>
          <td>{r.fechaCancelacion ? "Cancelada" : "Activa"}</td>
          <td>{'$' + parseFloat(r.totalReservaPropia).toFixed(2)}</td>
          <button type="button" class="btn btn-success" onClick={() => this.viewReserva(r)}>
            Consultar
          </button>
          <button type="button" class="btn btn-danger" onClick={() => this.deleteReserva(r.id)}
            hidden={r.fechaCancelacion}
          >
            Cancelar
          </button>
        </tr>
      );
      return (
        <div>
          <h1>Mis reservas</h1>
          <span style={{color: "red"}}>{this.state.error}</span>
          <hr />
          <table class="table">
              <thead>
              <tr>
                  <th scope="col">Código</th>
                  <th scope="col">Fecha de retiro</th>
                  <th scope="col">Lugar de retiro</th>
                  <th scope="col">Estado</th>
                  <th scope="col">Total</th>
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
}

export default ListaReservas;