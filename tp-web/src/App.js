import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import ListaVehiculos from './components/ListaVehiculos/ListaVehiculos';
import ListaReservas from './components/ListaReservas/ListaReservas';
import VerReserva from './components/VerReserva/VerReserva';
import CallbackOAuth from './components/CallbackOAuth/CallbackOAuth';
import api from './api';
import './App.css';

class App extends Component {

  constructor(props){
    super(props);
    this.state = {
      isAuthenticated: localStorage.getItem("token")
    }
    this.login = this.login.bind(this);
    this.logout = this.logout.bind(this);
  }

  login() {
    api.get('/auth/login')
      .then(res => {
        window.location = res.data;
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
    //localStorage.setItem("token", "aja");
    //this.setState({ isAuthenticated: true });
  }

  logout() {
    localStorage.removeItem("token");
    this.setState({ isAuthenticated: false });
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
            {
              this.state.isAuthenticated &&
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
            }
            </div>
            {
              !this.state.isAuthenticated ? (
                <button className="btn btn-success" onClick={this.login}>Iniciar sesión</button>
              ) : (
                <button className="btn btn-warning" onClick={this.logout}>Cerrar sesión</button>
              )
            }
          </nav>
          <main role="main" class="container">
            <Route exact path="/" component={Home} />
            <Route path="/vehiculos" component={ListaVehiculos}/>
            <Route path="/reservas" component={ListaReservas}/>
            <Route path="/reserva" component={VerReserva}/>
            <Route path="/callback" component={CallbackOAuth}/>
          </main>
        </div>
      </Router>
    );
  }
}

const Home = () => (
    <div class="starter-template">
      <h1>TP - IAEW - 2018</h1>
    </div>
);

export default App;
