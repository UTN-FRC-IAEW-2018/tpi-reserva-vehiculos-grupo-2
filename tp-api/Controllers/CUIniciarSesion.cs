using System;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using tp_api.InterfacesREST;

namespace tp_api.Controllers {
	public class CUIniciarSesion : Controller, RESTIniciarSesion  {

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

		[Route("api/auth/token")]
		public string VerificarUsuarioYPassword(string token) {
			//if (Us)
			return null;
		}
		public string GetCorreoUsuario(string token) {
			var client = new RestClient("http://ec2-54-87-197-49.compute-1.amazonaws.com/v1/oauth/introspect");
			var request = new RestRequest(Method.POST);
			request.AddHeader("Postman-Token", "5523331f-1aaa-4a88-b461-42abc91193be");
			request.AddHeader("Cache-Control", "no-cache");
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			request.AddParameter("undefined", "token=" + token + "&token_type_hint=access_token", ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);
			return response.Content;
		}
		public void CrearUsuario() {
			throw new System.Exception("Not implemented");
		}
		public void CrearCliente() {
			throw new System.Exception("Not implemented");
		}

		public void InicioExitoso(ref string mensaje) { 
			throw new System.Exception("Not implemented");
		}

		public void InicioFallido(ref string mensaje) {
			throw new System.Exception("Not implemented");
		}

	}

}
