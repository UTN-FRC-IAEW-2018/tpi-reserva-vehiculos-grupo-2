import React, { Component } from 'react';
import axios from 'axios';
import queryString from 'query-string';


class CallbackOAuth extends Component {
  constructor(props) {
    super(props);
    const params = queryString.parse(props.location.search);
    this.getToken(params.code);
  }

  getToken(code) {
    const headers = {
      "Content-Type": "application/x-www-form-urlencoded",
      "Authorization": "Bearer 20a3fd15-ac18-43b8-800b-e35adea2cd03"
    };
    const data = {
      "grant_type": "authorization_code",
      "code": code,
      "redirect_uri": "http://localhost:3000/callback"
    };
    axios.post('http://ec2-54-87-197-49.compute-1.amazonaws.com/v1/oauth/tokens', data, { headers })
      .then(res => {
        console.log(res);
        localStorage.setItem("token", res.access_token);
        
        /*api.post('/auth/token', { access_token: res.access_token })
          .then(res => {
            this.props.history.push('');
          })*/
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