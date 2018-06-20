import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import ListaVehiculos from './components/ListaVehiculos/ListaVehiculos';
import ListaReservas from './components/ListaReservas/ListaReservas';
import VerReserva from './components/VerReserva/VerReserva';
import './App.css';

class App extends Component {

  login(){
    return undefined;
  }

  render() {
    return (
      <Router>
        <div>
          <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
            <a class="navbar-brand" href="#">TP IAEW 2018</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
              <ul class="navbar-nav mr-auto">
                <li class="nav-item">
                  <Link className="nav-link" to="/">Inicio</Link>
                </li>
                <li class="nav-item">
                  <Link className="nav-link" to="/vehiculos">Vehículos</Link>
                </li>
                <li class="nav-item">
                  <Link className="nav-link" to="/reservas">Reservas</Link>
                </li>
              </ul>
            </div>
            <button className="btn btn-success" onPress={this.login()}>Iniciar sesión</button>
          </nav>
          <main role="main" class="container">
            <Route exact path="/" component={Home} />
            <Route path="/vehiculos" component={ListaVehiculos}/>
            <Route path="/reservas" component={ListaReservas}/>
            <Route path="/reserva" component={VerReserva}/>
          </main>
        </div>
      </Router>
    );
  }
}

const Home = () => (
    <div class="starter-template">
      <h1>TP - IAEW - 2018</h1>
      <p class="lead">React.js + .NET Core WebAPI</p>`
    </div>
);

export default App;
