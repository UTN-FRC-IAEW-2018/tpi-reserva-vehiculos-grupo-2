import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { Provider, connect } from "react-redux";
import { createStore, applyMiddleware } from "redux";
import {auth} from "./actions";
import {helpo} from "./reducers";
import thunk from "redux-thunk";
import ListaVehiculos from './components/ListaVehiculos/ListaVehiculos';
import ListaReservas from './components/ListaReservas/ListaReservas';
import VerReserva from './components/VerReserva/VerReserva';
import RegistrarCliente from './components/RegistrarCliente/RegistrarCliente';
import CallbackOAuth from './components/CallbackOAuth/CallbackOAuth';
import api from './api';
import './App.css';

let store = createStore(helpo, applyMiddleware(thunk));

class RootContainerComponent extends Component {

  constructor(props){
    super(props);
    this.login = this.login.bind(this);
    this.logout = this.logout.bind(this);
  }

  componentDidMount() {
    this.props.loadUser();
  } 

  login() {
    api.get('/auth/login')
      .then(res => {
        window.location = res.data;
      })
      .catch((error) => {
        this.setState({ error: "Hubo un problema al cargar su información." });
      })
  }

  logout() {
    this.props.logout();
  }

  render() {
    return (
      <Router>
        <div>
          <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
            <a class="navbar-brand" href=".">TP IAEW 2018</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
            {
              this.props.auth.isAuthenticated &&
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
              !this.props.auth.isAuthenticated ? (
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
            <Route path="/registrar-cliente" component={RegistrarCliente}/>
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

const mapStateToProps = state => {
  return {
    auth: state.auth,
  }
}


const mapDispatchToProps = dispatch => {
  return {
    loadUser: () => {
      return dispatch(auth.loadUser());
    },
    logout: () => {
      return dispatch(auth.logout());
    }
  }
}

let RootContainer = connect(mapStateToProps, mapDispatchToProps)(RootContainerComponent);

export default class App extends Component {
  render() {
    return (
      <Provider store={store}>
        <RootContainer />
      </Provider>
    )
  }
}
