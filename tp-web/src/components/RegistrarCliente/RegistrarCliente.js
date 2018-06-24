import React, { Component } from 'react';
import api from '../../api';


class RegistrarCliente extends Component {
  constructor(props) {
    super(props);
    this.state = {
      documento: '',
      nombre: '',
      apellido: '',
      error: ''
    }
    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveCliente = this.saveCliente.bind(this);
  }

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;
    this.setState({
      [name]: value,
    });
  }

  saveCliente() {
    if (this.validateCliente()) {
      const cliente = {
        documento: this.state.documento,
        nombre: this.state.nombre,
        apellido: this.state.apellido
      }
      api.put('', cliente)
        .then((res) => {
          this.props.history.push('');
        }).catch(function (error) {
          if (error.response){ console.log(error.response.status) }
          else { console.log('Error: ', error.message)}
      });
    }
  }

  validateCliente() {
    if (!(!isNaN(parseFloat(this.state.documento)) && isFinite(this.state.documento))) {
      this.setState({ error: "El valor de documento ingresado no es válido."});
      return false;
    }
    if (!this.state.nombre || !this.state.apellido) {
      this.setState({ error: "Complete todos los campos."});
      return false;
    }
    return true;
  }
 

  render() {
    return (
      <div>
        <h1>Complete sus datos de cliente</h1>
        <div className="form-group">
          <label for="dni">Documento</label>
          <input type="text" name="documento" className="form-control" value={this.state.documento} onChange={this.handleInputChange} />
          <label for="nombre">Nombre</label>
          <input type="text" name="nombre" className="form-control" value={this.state.nombre} onChange={this.handleInputChange} />
          <label for="apellido">Apellido</label>
          <input type="text" name="apellido" className="form-control" value={this.state.apellido} onChange={this.handleInputChange} />
          <span style={{color: "red"}}>{this.state.error}</span>
          <hr />
          <button className="btn btn-primary" onClick={this.saveCliente}>Guardar datos</button>
        </div>
      </div>
    );
  }
}

export default RegistrarCliente;