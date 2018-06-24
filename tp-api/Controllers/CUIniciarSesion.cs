using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using tp_api.InterfacesREST;
using tp_api.Controllers;
using Models;

namespace tp_api.Controllers {
	public class CUIniciarSesion : Controller, RESTIniciarSesion  {

		private readonly Context _context;

        public CUIniciarSesion(Context context)
        {
            _context = context;
		}
		[Route("api/auth/login")]
		public string IniciarSesion() {
			// Retorna ruta de login de OAuth
			string cliente = "grupo_nro2_client";
			string redirectUri = "http://localhost:3000/callback";
			return "http://ec2-54-87-197-49.compute-1.amazonaws.com/web/authorize?" +
						"client_id=" + cliente + "&redirect_uri=" + redirectUri +
							"&response_type=code&state=somestate&scope=read_write";
		}

		public string InicioExitoso() {
			throw new System.Exception("Not implemented");
		}

		[Route("api/auth/user")]
        [HttpGet("{code}")]
        public JsonResult Get(string code)
        {
			throw new NotImplementedException();
			/*
			string usuario = "";
			var token = GetToken(code); // Pedir token
			var usuarioOAuth = GetUsuarioOAuth(token); // Hacer inspect a OAuth
			Cliente cliente = GetCliente(mail); // En base al mail ver si está registrado
			if (cliente == null) {
				cliente = CrearCliente(); // Registrar si no está registrado
			}
			// Falta agregarle al token a lo que se devuelve a la SPA.
			return new JsonResult(usuario);
			 */
        }

        private Cliente GetCliente(string mail)
        {
            ClientesController cont = new ClientesController(_context);
			return cont.GetByEmail(mail);
        }

        private object GetUsuarioOAuth(object token)
        {
            throw new NotImplementedException();
        }

        private object GetToken(string code)
        {
            var client = new RestClient("http://ec2-54-87-197-49.compute-1.amazonaws.com/v1/oauth/tokens");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "4f489d7e-596e-4335-b6c3-2beed8ccb791");
            request.AddHeader("Authorization", "Basic dGVzdF9jbGllbnRfMTp0ZXN0X3NlY3JldA==");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", $"grant_type=authorization_code&code={code}&redirect_uri=https%3A%2F%2Fwww.example.com", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            
            //dESSERIALIZAR.


            return new JsonResult(response.Content);
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
