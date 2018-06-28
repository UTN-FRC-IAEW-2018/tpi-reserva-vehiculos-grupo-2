import React, { Component } from 'react';
import DateTimePicker from 'react-datetime-picker';
import Select from 'react-select';
import ListaVehiculos from '../ListaVehiculos/ListaVehiculos';
import ReservarVehiculo from '../ReservarVehiculo/ReservarVehiculo';
import api from '../../api';
import '../../../node_modules/react-select/dist/react-select.css';


class Vehiculos extends Component {
  constructor(props) {
    super(props);
    if (!localStorage.getItem("token")) { this.props.history.push('')}
    this.state = {
      vehiculos: undefined,
      vehiculo: undefined,
      paises: [],
      ciudades: [],
      lugares: [],
      pais: 0,
      ciudad: 0,
      fecha_hora_inicio: new Date(),
      fecha_hora_fin: new Date(new Date().getTime() + 24 * 60 * 60 * 1000),
      error: undefined
    }
    this.handleChange = this.handleChange.bind(this);
    this.handleChangeCiudad = this.handleChangeCiudad.bind(this);
    this.handleReservar = this.handleReservar.bind(this);
    this.handleFechaHoraInicioChange = this.handleFechaHoraInicioChange.bind(this);
    this.handleFechaHoraFinChange = this.handleFechaHoraFinChange.bind(this);
    this.loadVehiculos = this.loadVehiculos.bind(this);
  }

  handleValidation() {
    return this.state.fecha_hora_inicio < this.state.fecha_hora_fin;
  }

  loadVehiculos() {
    const desde = this.state.fecha_hora_inicio.toISOString();
    const hasta = this.state.fecha_hora_fin.toISOString();
    const ciudad = this.state.ciudad.value;
    if (this.handleValidation()) {
      api.get('/vehiculos?ciudad=' + ciudad + '&desde=' + desde + '&hasta=' + hasta)
        .then(res => {
          const vehiculosData = res.data;
          console.log(vehiculosData);
          this.setState({ vehiculos: vehiculosData, error: undefined});
        })
        .catch((error) => {
          this.setState({ error: "Hubo un problema al cargar su información." });
        })
    } else {
      this.setState({ error: "Revise las fechas seleccionadas." });
    }
  }

  loadPaises() {
    api.get('/paises/')
      .then(res => {
        const paisesData = res.data;
        this.loadCiudadesInicial(paisesData)
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  loadLugares() {
    api.get('/lugares/')
      .then(res => {
        const lugaresData = res.data;
        this.setState({lugares: lugaresData})
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }


  loadCiudadesInicial(paisesData) {
    api.get('/paises/' + paisesData[0].id + '/ciudades')
      .then(res => {
        const ciudadesData = res.data;
        this.setState({ 
          paises: paisesData,
          ciudades: ciudadesData,
          pais: { value: paisesData[0].id, label: paisesData[0].nombre },
          ciudad: { value: ciudadesData[0].id, label: ciudadesData[0].nombre },
        });
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }


  loadCiudadesPorPais(pais) {
    api.get('/geo/ciudad?pais=' + pais.value)
      .then(res => {
        const ciudadesData = res.data;
        this.setState({
          pais: pais,
          ciudades: ciudadesData,
          ciudad: { value: ciudadesData[0].id, label: ciudadesData[0].nombre },
          error: undefined});
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  componentDidMount() {
    this.loadLugares();
    this.loadPaises();
  }


  handleReservar(vehiculo){
    this.setState({vehiculo});
  }
 
  handleChangeCiudad = (selectedOption) => {
    this.setState({ ciudad: selectedOption });
  }

  handleFechaHoraInicioChange(fecha_hora) {
    this.setState({ fecha_hora_inicio: fecha_hora, fecha_hora_fin: fecha_hora });
  }

  handleFechaHoraFinChange(fecha_hora) {
    this.setState({ fecha_hora_fin: fecha_hora });
  }

  transformGeo(objetosApi) {
    let objetos = [];
    objetosApi.forEach(function(e) {
      objetos.push({ value: e.id, label: e.nombre});
    });
    return objetos;
  }

  handleChange = (selectedOption) => {
    this.loadCiudadesPorPais(selectedOption);
  }

  render() {
    
    if (!this.state.vehiculos) {
      const listaPaises = this.transformGeo(this.state.paises);
      const listaCiudades = this.transformGeo(this.state.ciudades);
      return (
        <div>
          <h1>Reservar vehículos</h1>
          <div className="col-md-6">
            <label for="pais">País</label>
            <Select 
              options={listaPaises} 
              name="pais"
              value={this.state.pais}
              onChange={this.handleChange}
            />
          </div>
          <div className="col-md-6">
            <label for="ciudad">Ciudad</label>
            <Select 
              name="ciudad"
              options={listaCiudades} 
              value={this.state.ciudad}
              onChange={this.handleChangeCiudad}
            /> 
          </div>
          <div className="form-group" style={{'margin-left':'20px'}}>
            <label for="inicio">Desde</label>
            <br />
            <DateTimePicker
              name="inicio"
              onChange={this.handleFechaHoraInicioChange}
              isClockOpen={false}
              value={this.state.fecha_hora_inicio}
            />
          </div>
          <div className="form-group" style={{'margin-left':'20px'}}>
            <label for="fin">Hasta</label>
            <br />
            <DateTimePicker
              name="fin"
              onChange={this.handleFechaHoraFinChange}
              isClockOpen={false}
              value={this.state.fecha_hora_fin}
            />
          </div>
          <div className="form-group" style={{'margin-left':'20px'}}>
            <button className="btn btn-primary" onClick={this.loadVehiculos}>Buscar vehículos</button>
            <span style={{color: "red"}}>{this.state.error}</span>
          </div>
          
        </div>
      );
    } else if (this.state.vehiculo) {
      return(
        <ReservarVehiculo vehiculo={this.state.vehiculo} lugares={this.state.lugares}
          desde={this.state.fecha_hora_inicio} hasta={this.state.fecha_hora_fin}
        />
      );
    } else {
      return(
        <ListaVehiculos vehiculos={this.state.vehiculos} reservar={this.handleReservar}/>
      );
    }
    
  }
}

export default Vehiculos;