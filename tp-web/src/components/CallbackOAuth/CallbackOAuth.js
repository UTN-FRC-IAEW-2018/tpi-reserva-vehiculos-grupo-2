import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from "react-redux";
import queryString from 'query-string';
import {auth} from "../../actions";



class CallbackOAuth extends Component {
  constructor(props) {
    super(props);
    const params = queryString.parse(props.location.search);
    this.getToken(params.code);
  }

  getToken(code) {
    this.props.login(code);
  }

  render() {
    if (this.props.isAuthenticated) {
      return <Redirect to="/registrar-cliente" />
    } else {
      return (
        <div>
          <label>Cargando...</label>
        </div>
      );
    }
  }
}

const mapStateToProps = state => {return { isAuthenticated: state.auth.isAuthenticated }}

const mapDispatchToProps = dispatch => {
  return {
    login: (code) => {
      return dispatch(auth.login(code));
    }
  };
}
export default connect(mapStateToProps, mapDispatchToProps)(CallbackOAuth);