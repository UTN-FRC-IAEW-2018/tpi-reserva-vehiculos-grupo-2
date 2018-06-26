import React, { Component } from 'react';
import api from '../../api';
import queryString from 'query-string';


class CallbackOAuth extends Component {
  constructor(props) {
    super(props);
    const params = queryString.parse(props.location.search);
    this.getToken(params.code);
  }

  getToken(code) {
    api.get('/auth/user?code=' + code)
      .then(res => {
        console.log(res);
        localStorage.setItem("token", res.data.token);
        localStorage.setItem("email", res.data.email);
        if (res.data.nuevo) {
          this.props.history.push('/registrar-cliente')
        } else {
          this.props.history.push('');
        }
      })
      .catch((error) => {
        //console.log(error);
        localStorage.setItem("token", "hola");
        this.props.history.push('');
      })
  }

  render() {
    return (
      <div>
        <label>Cargando...</label>
      </div>
    );
  }
}

export default CallbackOAuth;