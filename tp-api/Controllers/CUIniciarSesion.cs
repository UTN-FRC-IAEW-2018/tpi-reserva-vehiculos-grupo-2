using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using tp_api.InterfacesREST;
using tp_api.Controllers;
using Models;
using Clases;

namespace tp_api.Controllers {
    [Route("api/auth")]
    public class CUIniciarSesion : Controller, RESTIniciarSesion  {

		private readonly Context _context;

        private string redirect_url = "http%3A%2F%2Flocalhost:3000%2Fcallback";
        private string local_redirect_url = "http%3A%2F%2Flocalhost:14089%2Fapi%2Fauth%2Fuser";


        public CUIniciarSesion(Context context)
        {
            _context = context;
		}
		[Route("login")]
		public string IniciarSesion() {
			// Retorna ruta de login de OAuth
			string cliente = "grupo_nro2_client";
            string url = "http://ec2-54-87-197-49.compute-1.amazonaws.com/web/authorize?" +
                        "client_id=" + cliente + "&redirect_uri=" + local_redirect_url +
                            "&response_type=code&state=somestate&scope=read_write";
            return url;
		}
        [Route("oauth")]
        public ActionResult OAuth()
        {
            return Redirect(IniciarSesion());
        }

        public string InicioExitoso() {
			throw new System.Exception("Not implemented");
		}

		[HttpGet("{code}"), Route("user")]
        public JsonResult Get(string code)
        {
            if (Request.Method != "GET")
            {
                return Json("No era aca");
            }
            var token = GetToken(code); // Pedir token
            
			var usuarioOAuth = GetUsuarioOAuth(token); // Hacer inspect a OAuth

            var controller = new UsuariosController(_context);
            var user = controller.GetByOAuth(usuarioOAuth);

            JObject res = new JObject();

            res["email"] = user.Email;
            res["token"] = user.AccessToken;
            if (user.Username == null)
                res["nuevo"] = true;
            else
            {
                res["nuevo"] = false;
                res["dni"] = user.DNI;
                res["nombre"] = user.Nombre;
                res["username"] = user.Username;
                res["apellido"] = user.Apellido;
            }
            

            return Json(res);
            
        }

        [Route("user"), HttpPost()]
        public IActionResult Post(Usuario asdf)
        {
            
            var jo = new JObject();
            jo["email"] = "ad";
            jo["token"] = "qwer";
            return Json(jo);
        }

        private Cliente GetCliente(string mail)
        {
            ClientesController cont = new ClientesController(_context);
			return cont.GetByEmail(mail);
        }




        // metodos privados
        private OAuthUser GetUsuarioOAuth(Token token)
        {
            var client = new RestClient("http://ec2-54-87-197-49.compute-1.amazonaws.com/v1/oauth/introspect");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Basic Z3J1cG9fbnJvMl9jbGllbnQ6dGVzdF9zZWNyZXQ=");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("application/x-www-form-urlencoded", $"token_type_hint=access_token&token={token.TokenAccess}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            var jo = JObject.Parse(response.Content);
            token.Active = jo.Value<bool>("active");

            DateTime exp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            exp = exp.AddSeconds(jo.Value<long>("exp"));
            token.Expires = exp;

            var user = new OAuthUser();
            user.Token = token;
            user.Username = jo.GetValue("username").ToString();
            

            return user;
        }

        private Token GetToken(string code)
        {
            var client = new RestClient("http://ec2-54-87-197-49.compute-1.amazonaws.com/v1/oauth/tokens");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Basic Z3J1cG9fbnJvMl9jbGllbnQ6dGVzdF9zZWNyZXQ=");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=authorization_code&code={code}&redirect_uri={local_redirect_url}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            
            var obj = JObject.Parse(response.Content);
            var t = new Token();
            t.TokenAccess = obj.GetValue("access_token").ToString();
            t.Refresh = obj.GetValue("refresh_token").ToString();

            return t;
        }

		public Cliente CrearCliente() {
			throw new System.Exception("Not implemented");
		}

		public void InicioExitoso(ref string mensaje) { 
			
		}

		public void InicioFallido(ref string mensaje) {
			
		}


	}

}
