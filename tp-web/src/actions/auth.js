import api from '../api';

export const loadUser = () => {
  return (dispatch, getState) => {
    const token = getState().auth.token;
    if (token) {
      dispatch({type: 'USER_LOADED' });
      return null;
    } else {
      dispatch({type: "AUTHENTICATION_ERROR", data: "Error de autenticación."});
    }
  }
}

export const login = (code) => {
  return (dispatch, getState) => {
    api.get('/auth/user?code=' + code)
      .then(res => {
        console.log(res);
        dispatch({type: 'LOGIN_SUCCESSFUL', data: res.data });
        return res.data;
      })
      .catch((error) => {
        dispatch({type: "AUTHENTICATION_ERROR", data: error.response.data});
        throw error.response.data;
      })
  }
}

export const logout = () => {
  return (dispatch, getState) => {
    dispatch({type: 'LOGOUT_SUCCESSFUL'});
    return null;
  }
}