import React, { Component } from 'react';
import Select from 'react-select';
import { Redirect } from 'react-router-dom';
import api from '../../api';

class ReservarVehiculo extends Component {
  constructor(props) {
    super(props);
    if (!localStorage.getItem("token")) { this.props.history.push('')}
    this.state = {
      error: undefined,
      origen: { value: this.props.lugares[0].id, label: this.props.lugares[0].nombre },
      destino: { value: this.props.lugares[0].id, label: this.props.lugares[0].nombre }
    }
    this.handleChangeOrigen = this.handleChangeOrigen.bind(this);
    this.handleChangeDestino = this.handleChangeDestino.bind(this);
    this.handleReservar = this.handleReservar.bind(this);
  }
 
  transformLugares(objetosApi) {
    let objetos = [];
    objetosApi.forEach(function(e) {
      objetos.push({ value: e.id, label: e.nombre});
    });
    return objetos;
  }

  handleChangeOrigen = (selectedOption) => {
    this.setState({ origen: selectedOption });
  }

  handleChangeDestino = (selectedOption) => {
    this.setState({ destino: selectedOption });
  }

  handleReservar(){
    const reserva = JSON.stringify({
      token: localStorage.getItem("token"),
      desde: this.props.desde.toISOString(),
      lugarOrigen: this.state.origen.value,
      hasta: this.props.hasta.toISOString(),
      lugarDestino: this.state.destino.value,
      idVehCiud: this.props.vehiculo.vehiculoCiudadId
    });
    let registrado;
    api.post('/clientes/' + localStorage.getItem("dni") + '/reservas', reserva, {
      headers: {
        'Content-Type': 'application/json',
      }}).then(res => {
        registrado = true;
        this.setState({ registrado: true });
      })
      .catch((error) => {
        console.log(error);
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }
 
  render() {
    if (this.state.registrado) {
      return <Redirect to="/reservas" />
    }
    if (this.props.vehiculo) {
      const lugares = this.transformLugares(this.props.lugares);
      return (
        <div>
          <div className="col-md-6">
            <h2>Finalizar reserva</h2>
            <h4>{this.props.vehiculo.marca + ' ' + this.props.vehiculo.modelo}</h4>
            <label for="origen">Lugar de origen</label>
            <Select 
              name="origen"
              options={lugares} 
              value={this.state.origen}
              onChange={this.handleChangeOrigen}
            /> 
          </div>
          <div className="col-md-6">
            <label for="destino">Lugar de destino</label>
            <Select 
              name="destino"
              options={lugares} 
              value={this.state.destino}
              onChange={this.handleChangeDestino}
            /> 
          </div>
          <br />
          <button className="btn btn-success" onClick={this.handleReservar}>Reservar vehículo</button>
        </div>
      );
    } else {
      return (<div></div>)
    }
  }
}

export default ReservarVehiculo;