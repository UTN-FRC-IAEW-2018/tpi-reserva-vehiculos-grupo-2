import React, { Component } from 'react';
import api from '../../api';


class VerReserva extends Component {
  constructor(props) {
    super(props);
    let reserva;
    if(this.props.history.location.state &&
      this.props.history.location.state.reserva_id) {
      reserva = this.props.history.location.state.reserva_id;
    } else {
      this.props.history.push('reservas');
    }
    this.state = {
      reserva_id: reserva,
      reserva: undefined,
      error: undefined
    }
  }

  loadReserva() {
    api.get('/api/vehiculos/' + this.state.reserva_id)
      .then(res => {
        const reservaData = res.data;
        this.setState({ reserva: reservaData});
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  componentDidMount() {
    this.loadReserva();
  }


  render() {
    return (
      <div>
        <h1>Reserva</h1>
        <h2>Nombre</h2>
        <p>Descripción</p>
        <b>$230</b>
        <hr />
        <span style={{color: "red"}}>{this.state.error}</span>
      </div>
    );
  }
}

export default VerReserva;