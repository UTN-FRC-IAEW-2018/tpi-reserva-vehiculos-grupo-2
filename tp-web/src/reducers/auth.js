const initialState = {
    token: localStorage.getItem("token"),
    email: localStorage.getItem("email"),
    isAuthenticated: null,
    errors: {},
  };
  
  export default function auth(state=initialState, action) {
    switch (action.type) {
      case 'USER_LOADED':
        return {...state, isAuthenticated: true};
      case 'LOGIN_SUCCESSFUL':
        localStorage.setItem("token", action.data.token);
        localStorage.setItem("email", action.data.email);
        localStorage.setItem("nuevo", action.data.nuevo);
        return {...state, ...action.data, isAuthenticated: true, errors: null};
      case 'AUTHENTICATION_ERROR':
        localStorage.removeItem("token");
        localStorage.removeItem("email");
        localStorage.removeItem("nuevo");
        return {...state, errors: null, token: null, email: null,
          isAuthenticated: false};
      case 'LOGOUT_SUCCESSFUL':
        localStorage.removeItem("token");
        localStorage.removeItem("email");
        localStorage.removeItem("nuevo");
        return {...state, errors: action.data, token: null, email: null,
          isAuthenticated: false};
      default:
        return state;
      }
  }