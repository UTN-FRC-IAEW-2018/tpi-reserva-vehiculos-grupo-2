import React, { Component } from 'react';
import moment from 'moment';


class VerReserva extends Component {
  constructor(props) {
    super(props);
    if(!this.props.reserva) {
      this.props.history.push('reservas');
    }
    this.state = {
      error: undefined
    }
  }

  render() {
    const reserva = this.props.reserva;
    return (
      <div>
        <h1>Reserva {reserva.codigo}</h1>
        <p><b>Fecha de retiro:</b> {moment(reserva.fechaRetiro).format('DD/MM/YYYY HH:mm')}</p>
        <p><b>Lugar de retiro:</b> {reserva.lugarRetiro}</p>
        <p><b>Fecha de devolución:</b> {moment(reserva.fechaDevolucion).format('DD/MM/YYYY HH:mm')}</p>
        <p><b>Lugar de devolución:</b> {reserva.lugarDevolucion}</p>
        <h4><b>Estado:</b> {reserva.fechaCancelacion ? "Cancelada" : "Activa"}</h4>
        <h4><b>Total:</b> {'$' + parseFloat(reserva.totalReservaPropia).toFixed(2)}</h4>
        <hr />
        <span style={{color: "red"}}>{this.state.error}</span>
        <button className="btn btn-default" onClick={this.props.return}>Volver a Mis Reservas</button>
      </div>
    );
  }
}

export default VerReserva;